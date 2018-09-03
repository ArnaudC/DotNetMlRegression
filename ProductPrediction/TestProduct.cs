using System;
using System.Collections.Generic;
using System.Text;

namespace ProductPrediction
{
    static class TestProduct
    {
        internal static readonly Product Product1 = new Product
        {
            Sugars_100g = 0, // actual is 7.14

            Brands = "Shurfine,  Topco Associates  Inc.",
            Calcium_100g = 0.143f,
            Cholesterol_100g = 0,
            Energy_100g = 1644,
            Fat_100g = 3.57f,
            Fiber_100g = 0,
            Iron_100g = 0.00514f,
            Salt_100g = 3.53822f,
            Proteins_100g = 10.71f,
            SaturatedFat_100g = 0,
            Sodium_100g = 1.393f,
            TransFat_100g = 0,
            VitaminC_100g = 0,
            Carbohydrates_100g = 75f
        };
    }
}
