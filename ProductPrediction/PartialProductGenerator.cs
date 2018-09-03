using Microsoft.ML.Runtime.Api;

namespace ProductPrediction
{
    public partial class Product {
    
        [Column("68")]
        public float Energy_100g;

        // [Column("69")]
        // public float EnergyFromFat_100g;

        [Column("70")]
        public float Fat_100g;

        [Column("71")]
        public float SaturatedFat_100g;

        // [Column("72")]
        // public float ButyricAcid_100g;

        // [Column("73")]
        // public float CaproicAcid_100g;

        // [Column("74")]
        // public float CaprylicAcid_100g;

        // [Column("75")]
        // public float CapricAcid_100g;

        // [Column("76")]
        // public float LauricAcid_100g;

        // [Column("77")]
        // public float MyristicAcid_100g;

        // [Column("78")]
        // public float PalmiticAcid_100g;

        // [Column("79")]
        // public float StearicAcid_100g;

        // [Column("80")]
        // public float ArachidicAcid_100g;

        // [Column("81")]
        // public float BehenicAcid_100g;

        // [Column("82")]
        // public float LignocericAcid_100g;

        // [Column("83")]
        // public float CeroticAcid_100g;

        // [Column("84")]
        // public float MontanicAcid_100g;

        // [Column("85")]
        // public float MelissicAcid_100g;

        // [Column("86")]
        // public float MonounsaturatedFat_100g;

        // [Column("87")]
        // public float PolyunsaturatedFat_100g;

        // [Column("88")]
        // public float Omega3Fat_100g;

        // [Column("89")]
        // public float AlphaLinolenicAcid_100g;

        // [Column("90")]
        // public float EicosapentaenoicAcid_100g;

        // [Column("91")]
        // public float DocosahexaenoicAcid_100g;

        // [Column("92")]
        // public float Omega6Fat_100g;

        // [Column("93")]
        // public float LinoleicAcid_100g;

        // [Column("94")]
        // public float ArachidonicAcid_100g;

        // [Column("95")]
        // public float GammaLinolenicAcid_100g;

        // [Column("96")]
        // public float DihomoGammaLinolenicAcid_100g;

        // [Column("97")]
        // public float Omega9Fat_100g;

        // [Column("98")]
        // public float OleicAcid_100g;

        // [Column("99")]
        // public float ElaidicAcid_100g;

        // [Column("100")]
        // public float GondoicAcid_100g;

        // [Column("101")]
        // public float MeadAcid_100g;

        // [Column("102")]
        // public float ErucicAcid_100g;

        // [Column("103")]
        // public float NervonicAcid_100g;

        [Column("104")]
        public float TransFat_100g;

        [Column("105")]
        public float Cholesterol_100g;

        [Column("106")]
        public float Carbohydrates_100g;

        // [Column("108")]
        // public float Sucrose_100g;

        // [Column("109")]
        // public float Glucose_100g;

        // [Column("110")]
        // public float Fructose_100g;

        // [Column("111")]
        // public float Lactose_100g;

        // [Column("112")]
        // public float Maltose_100g;

        // [Column("113")]
        // public float Maltodextrins_100g;

        // [Column("114")]
        // public float Starch_100g;

        // [Column("115")]
        // public float Polyols_100g;

        [Column("116")]
        public float Fiber_100g;

        [Column("117")]
        public float Proteins_100g;

        // [Column("118")]
        // public float Casein_100g;

        // [Column("119")]
        // public float SerumProteins_100g;

        // [Column("120")]
        // public float Nucleotides_100g;

        [Column("121")]
        public float Salt_100g;

        [Column("122")]
        public float Sodium_100g;

        // [Column("123")]
        // public float Alcohol_100g;

        // [Column("124")]
        // public float VitaminA_100g;

        // [Column("125")]
        // public float BetaCarotene_100g;

        // [Column("126")]
        // public float VitaminD_100g;

        // [Column("127")]
        // public float VitaminE_100g;

        // [Column("128")]
        // public float VitaminK_100g;

        [Column("129")]
        public float VitaminC_100g;

        // [Column("130")]
        // public float VitaminB1_100g;

        // [Column("131")]
        // public float VitaminB2_100g;

        // [Column("132")]
        // public float VitaminPp_100g;

        // [Column("133")]
        // public float VitaminB6_100g;

        // [Column("134")]
        // public float VitaminB9_100g;

        // [Column("135")]
        // public float Folates_100g;

        // [Column("136")]
        // public float VitaminB12_100g;

        // [Column("137")]
        // public float Biotin_100g;

        // [Column("138")]
        // public float PantothenicAcid_100g;

        // [Column("139")]
        // public float Silica_100g;

        // [Column("140")]
        // public float Bicarbonate_100g;

        // [Column("141")]
        // public float Potassium_100g;

        // [Column("142")]
        // public float Chloride_100g;

        [Column("143")]
        public float Calcium_100g;

        // [Column("144")]
        // public float Phosphorus_100g;

        [Column("145")]
        public float Iron_100g;

        // [Column("146")]
        // public float Magnesium_100g;

        // [Column("147")]
        // public float Zinc_100g;

        // [Column("148")]
        // public float Copper_100g;

        // [Column("149")]
        // public float Manganese_100g;

        // [Column("150")]
        // public float Fluoride_100g;

        // [Column("151")]
        // public float Selenium_100g;

        // [Column("152")]
        // public float Chromium_100g;

        // [Column("153")]
        // public float Molybdenum_100g;

        // [Column("154")]
        // public float Iodine_100g;

        // [Column("155")]
        // public float Caffeine_100g;

        // [Column("156")]
        // public float Taurine_100g;

        // [Column("157")]
        // public float Ph_100g;

        // [Column("158")]
        // public float FruitsVegetablesNuts_100g;

        // [Column("159")]
        // public float FruitsVegetablesNutsEstimate_100g;

        // [Column("160")]
        // public float CollagenMeatProteinRatio_100g;

        // [Column("161")]
        // public float Cocoa_100g;

        // [Column("162")]
        // public float Chlorophyl_100g;

        // [Column("163")]
        // public float CarbonFootprint_100g;

        // [Column("164")]
        // public float NutritionScoreFr_100g;

        // [Column("165")]
        // public float NutritionScoreUk_100g;

        // [Column("166")]
        // public float GlycemicIndex_100g;

        // [Column("167")]
        // public float WaterHardness_100g;

        // [Column("168")]
        // public float Choline_100g;

        // [Column("169")]
        // public float Phylloquinone_100g;

        // [Column("170")]
        // public float BetaGlucan_100g;

        // [Column("171")]
        // public float Inositol_100g;

        // [Column("172")]
        // public float Carnitine_100g;

    }
}
