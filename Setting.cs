using Colossal;
using Colossal.IO.AssetDatabase;
using Game;
using Game.City;
using Game.Modding;
using Game.Settings;
using Game.UI;

namespace TradingCostTweaker
{
    [FileLocation($"ModsSettings\\StarQ\\{nameof(TradingCostTweaker)}")]
    [SettingsUITabOrder(ServiceTab, CargoTab, AboutTab)]
    [SettingsUIGroupOrder(ElectricityGroup, WaterGroup, OtherServiceGroup, ControlGroup)]
    [SettingsUIShowGroupName(ElectricityGroup, WaterGroup, OtherServiceGroup, ControlGroup)]
    public class Setting : ModSetting
    {
        private readonly VanillaData VanillaData = new();
        //private readonly OutsideTradeSystem outsideTradeSystem;

        public const string ServiceTab = "Service";
        public const string WaterGroup = "Water & Sewage";
        public const string ElectricityGroup = "Electricity";
        public const string OtherServiceGroup = "Other Service Fees";
        public const string ControlGroup = "Bulk Options";
        public const string Free1 = "Make Services Free";
        public const string Reset1 = "Reset Service Costs to Vanilla";

        public const string CargoTab = "Cargo";
        public const string RoadGroup = "Road";
        public const string TrainGroup = "Train";
        public const string ShipGroup = "Ship";
        public const string AirGroup = "Air";

        public const string AboutTab = "About";
        public const string InfoGroup = "Info";

        private string TextMaker(string value, string type, string pop = null)
        {
            string unit = "";
            switch (type)
            {
                case "electricity":
                    unit = " per kW";
                    break;
                case "water":
                    unit = " per 100m³";
                    break;
                default:
                    unit = $" per {pop} citizens";
                    break;
            };
            return $"₵ {value}{unit} per month";
        }

        //public string GameOrNot(bool value)
        //{
        //    if (value)
        //    {
        //        return "ItIsGame";
        //    }
        //    else
        //    {
        //        return "ItIsNotGame";
        //    }
        //}

        public Setting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        [SettingsUISection(ServiceTab, ElectricityGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int ElectricityImportPrice { get; set; }
        [SettingsUISection(ServiceTab, ElectricityGroup)]
        public string ElectricityImportPriceValue => TextMaker((ElectricityImportPrice * VanillaData.ElectricityImportPrice / 10).ToString(), "electricity");


        [SettingsUISection(ServiceTab, ElectricityGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int ElectricityExportPrice { get; set; }
        [SettingsUISection(ServiceTab, ElectricityGroup)]
        public string ElectricityExportPriceValue => TextMaker((ElectricityExportPrice * VanillaData.ElectricityExportPrice / 10).ToString(), "electricity");


        [SettingsUISection(ServiceTab, WaterGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int WaterImportPrice { get; set; }
        [SettingsUISection(ServiceTab, WaterGroup)]
        public string WaterImportPriceValue => TextMaker((WaterImportPrice * VanillaData.WaterImportPrice).ToString(), "water");

        [SettingsUISection(ServiceTab, WaterGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int WaterExportPrice { get; set; }
        [SettingsUISection(ServiceTab, WaterGroup)]
        public string WaterExportPriceValue => TextMaker((WaterExportPrice * VanillaData.WaterExportPrice).ToString(), "water");

        [SettingsUISection(ServiceTab, WaterGroup)]
        [SettingsUISlider(min = 0, max = 100, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int WaterExportPollutionTolerance { get; set; }

        [SettingsUISection(ServiceTab, WaterGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int SewageExportPrice { get; set; }
        [SettingsUISection(ServiceTab, WaterGroup)]
        public string SewageExportPriceValue => TextMaker((SewageExportPrice * VanillaData.SewageExportPrice).ToString(), "water");


        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 1000, max = 10000, step = 500, scalarMultiplier = 1, unit = Unit.kInteger)]
        public int PopulationMultiplier { get; set; }
        //[SettingsUISection(ServiceTab, OtherServiceGroup)]
        //public string Pop => GameOrNot(outsideTradeSystem.IsGameMode);
        //public string Pop => outsideTradeSystem.populationValue+"\n"+ GameOrNot(outsideTradeSystem.IsGameMode);

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float PoliceFee { get; set; }
        //[SettingsUIHideByCondition]
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string PoliceFeeValue => TextMaker((PoliceFee * VanillaData.PoliceFee / 100d).ToString(), "", PopulationMultiplier.ToString());

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float AmbulanceFee { get; set; }
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string AmbulanceFeeValue => TextMaker((AmbulanceFee * VanillaData.AmbulanceFee / 100d).ToString(), "", PopulationMultiplier.ToString());

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float HearseFee { get; set; }
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string HearseFeeValue => TextMaker((HearseFee * VanillaData.HearseFee / 100d).ToString(), "", PopulationMultiplier.ToString());

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float FireEngineFee { get; set; }
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string FireEngineFeeValue => TextMaker((FireEngineFee * VanillaData.FireEngineFee / 100d ).ToString(), "", PopulationMultiplier.ToString());

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float GarbageFee { get; set; }
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string GarbageFeeValue => TextMaker((GarbageFee * VanillaData.GarbageFee / 100d).ToString(), "", PopulationMultiplier.ToString());


        [SettingsUISection(ServiceTab, ControlGroup)]
        [SettingsUIButton]
        public bool FreeButton1 { set { MakeFree(); } }

        [SettingsUISection(ServiceTab, ControlGroup)]
        [SettingsUIButton]
        public bool ResetButton1 { set { SetDefaults(); } }


        [SettingsUISection(CargoTab, RoadGroup)]
        public string ComingSoon => "Cargo Cost control options are coming soon...";
        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 0.01f, unit = Unit.kFloatThreeFractions)]
        //public float RoadWeightMultiplier { get; set; }

        //[SettingsUISection(CargoTab, RoadGroup)]
        //[SettingsUISlider(min = 0, max = 100, step = 1, scalarMultiplier = 0.01f, unit = Unit.kFloatThreeFractions)]
        //public float RoadDistanceMultiplier { get; set; }


        [SettingsUISection(AboutTab, InfoGroup)]
        public string NameText => Mod.Name;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string VersionText => Mod.Version;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string AuthorText => Mod.Author;

        public override void SetDefaults()
        {
            ElectricityImportPrice = 100;
            ElectricityExportPrice = 100;
            WaterImportPrice = 100;
            WaterExportPrice = 100;
            WaterExportPollutionTolerance = 10;
            SewageExportPrice = 100;
            GarbageFee = 100;
            AmbulanceFee = 100;
            HearseFee = 100;
            FireEngineFee = 100;
            PoliceFee = 100;
            PopulationMultiplier = 1000;
            //RoadWeightMultiplier = 0.02f;
            //RoadDistanceMultiplier = 0.04f;
        }
        public void MakeFree()
        {
            ElectricityImportPrice = 0;
            ElectricityExportPrice = 0;
            WaterImportPrice = 0;
            WaterExportPrice = 0;
            WaterExportPollutionTolerance = 100;
            SewageExportPrice = 0;
            GarbageFee = 0;
            AmbulanceFee = 0;
            HearseFee = 0;
            FireEngineFee = 0;
            PoliceFee = 0;
            PopulationMultiplier = 1000;
            //RoadWeightMultiplier = 0.02f;
            //RoadDistanceMultiplier = 0.04f;
        }
    }
}
