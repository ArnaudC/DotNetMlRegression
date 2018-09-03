using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Models;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text;
using System.Reflection;
using Microsoft.ML.Runtime.Api;
using System.Collections.Generic;
using System.Linq;

namespace ProductPrediction
{
    class Program
    {
        static readonly string _datapath = Path.Combine(Environment.CurrentDirectory, "data", "productSugar-train.csv");
        static readonly string _testdatapath = Path.Combine(Environment.CurrentDirectory, "data", "productSugar-test.csv");
        static readonly string _modelpath = Path.Combine(Environment.CurrentDirectory, "data", "Model.zip");
        static readonly string _onnxPath = Path.Combine(Environment.CurrentDirectory, "data", "SaveModelToOnnxTest.onnx");
        static readonly string _onnxAsJsonPath = Path.Combine(Environment.CurrentDirectory, "data", "SaveModelToOnnxTest.json");
        static readonly char _separator = '\t';

        static async Task Main(string[] args)
        {
            try {
                Console.WriteLine(Environment.CurrentDirectory);
                ReadFirstLine<Product>();
                PredictionModel<Product, ProductSugars_100gPrediction> model = await Train();
                Evaluate(model);

                ProductSugars_100gPrediction prediction = model.Predict(TestProduct.Product1);
                Console.WriteLine("Predicted Sugars_100g: {0}, actual Sugars_100g: 8.75", prediction.Sugars_100g);

                // export modle to the ONNX format : C:\Users\aco\Dropbox\Pro\1.Softfluent\dev\DotnetMachineLearning\4.ProductPrediction\ProductPrediction\data\SaveModelToOnnxTest.onnx
                ConvertToOnnx(model);
            } catch (Exception e) {
                System.Console.WriteLine(e);
            }
        }

        public static async Task<PredictionModel<Product, ProductSugars_100gPrediction>> Train()
        {
            var pipeline = new LearningPipeline();
            pipeline.Add(new TextLoader(_datapath).CreateFrom<Product>(useHeader: true, separator: _separator));
            pipeline.Add(new ColumnCopier(("Sugars_100g", "Label")));
            pipeline.Add(new CategoricalOneHotVectorizer("Brands")); // Une colonne pour chaque catégorie
            var inputColumns = GetInputColumnsByReflexion<Product>("Sugars_100g");
            pipeline.Add(new ColumnConcatenator("Features", inputColumns)); // toutes les colonnes d'entrée, sauf la colonne de sortie
            pipeline.Add(
                new FastTreeRegressor() // Rms = 11,0090910814102, RSquared = 0,772706327174631
                // new FastForestRegressor() // Rms = 12,4792795720001, RSquared = 0,707945807219669
                // new FastTreeTweedieRegressor() // Rms = 19,9128086162614, RSquared = 0,256382748993251
                // new OnlineGradientDescentRegressor() { NumIterations = 200 } // perceptron, Rms = 15,5193043311758, RSquared = 0,416443091005237
                // new StochasticDualCoordinateAscentRegressor() // linear regression Rms = 15,7491102034943, RSquared = 0,399032813278095
            );
            PredictionModel<Product, ProductSugars_100gPrediction> model = pipeline.Train<Product, ProductSugars_100gPrediction>();
            await model.WriteAsync(_modelpath);
            return model;
        }
 
        private static string[] GetInputColumnsByReflexion<T>(string outputColumn)
        {
            var res = new List<string>();
            var fields = (typeof(T)).GetFields();
            foreach (var field in fields)
            {
                var name = field.Name;
                if (name != outputColumn)
                    res.Add(name);
            }
            return res.ToArray();
        }

        private static void Evaluate(PredictionModel<Product, ProductSugars_100gPrediction> model)
        {
            var testData = new TextLoader(_testdatapath).CreateFrom<Product>(useHeader: true, separator: _separator);
            var evaluator = new RegressionEvaluator();
            RegressionMetrics metrics = evaluator.Evaluate(model, testData);

            Console.WriteLine($"Rms = {metrics.Rms}");
            Console.WriteLine($"RSquared = {metrics.RSquared}");
        }

        private static void ConvertToOnnx(PredictionModel model)
        {
            try {
            OnnxConverter converter = new OnnxConverter()
            {
                InputsToDrop = new[] { "Label" },
                OutputsToDrop = new[] { "Label", "Features" },
                Onnx = _onnxPath,
                Json = _onnxAsJsonPath,
                Domain = "com.mydomain"
            };
            converter.Convert(model);
            // Strip the version.
            var fileText = File.ReadAllText(_onnxAsJsonPath);
            fileText = Regex.Replace(fileText, "\"producerVersion\": \"([^\"]+)\"", "\"producerVersion\": \"##VERSION##\"");
            File.WriteAllText(_onnxAsJsonPath, fileText);
                            
            } catch (Exception e) {
                System.Console.WriteLine(e);
            }
        }

        private static void ReadFirstLine<T>()
        {
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(_datapath))
            using (var streamReader = new StreamReader(fileStream, Encoding.BigEndianUnicode, true, BufferSize))
            {
                string line;
                var lineNumber = 1;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (lineNumber == 2)
                    {
                        var s = line.Split("\t");
                        var fields = (typeof(Product)).GetFields();
                        foreach (var field in fields)
                        {
                            var name = field.Name;
                            var attribute = (ColumnAttribute)field.GetCustomAttributes(false)[0];//(typeof(ColumnAttribute));
                            var ordinal = attribute.Ordinal;
                            int index = int.Parse(ordinal);
                            var value = s[index];
                            Console.WriteLine($"(name, index, value) = ({name}, {index}, {value})");
                        }
                    }
                    lineNumber++;
                    if (lineNumber >= 3)
                        break;
                }
            }
        }
    }
}
