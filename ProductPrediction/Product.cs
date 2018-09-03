using Microsoft.ML.Runtime.Api;

namespace ProductPrediction
{
    public partial class Product
    {
        [Column("13")]
        public string Brands; // add categorial variables here

        [Column("107")]
        public float Sugars_100g;
    }

    public class ProductSugars_100gPrediction
    {
        [ColumnName("Score")]
        public float Sugars_100g;
    }
}