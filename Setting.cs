using Colossal;
using Colossal.IO.AssetDatabase;
using Colossal.Json;
using Game;
using Game.City;
using Game.Modding;
using Game.Settings;
using Game.UI;
using System;

namespace TradingCostTweaker
{
    [FileLocation($"ModsSettings\\StarQ\\{nameof(TradingCostTweaker)}")]
    [SettingsUITabOrder(ServiceTab, CargoTab, AboutTab)]
    [SettingsUIGroupOrder(ElectricityGroup, WaterGroup, OtherServiceGroup, ControlGroup1, RoadGroup, TrainGroup, ShipGroup, AirGroup, ControlGroup2, InfoGroup)]
    [SettingsUIShowGroupName(ElectricityGroup, WaterGroup, OtherServiceGroup, ControlGroup1, RoadGroup, TrainGroup, ShipGroup, AirGroup, ControlGroup2, InfoGroup)]
    //[SettingsUIGroupOrder()]
    //[SettingsUIShowGroupName(RoadGroup, TrainGroup, ShipGroup, AirGroup)]
    public class Setting : ModSetting
    {
        private readonly VanillaData VanillaData = new();
        private readonly OutsideTradeSystem outsideTradeSystem = new();

        public const string ServiceTab = "Service";
        public const string WaterGroup = "Water & Sewage";
        public const string ElectricityGroup = "Electricity";
        public const string OtherServiceGroup = "Other Service Fees";
        public const string ControlGroup1 = "Services Bulk Options";
        public const string Free1 = "Make Services Free";
        public const string Reset1 = "Reset Service Costs to Vanilla";

        public const string CargoTab = "Cargo";
        public const string RoadGroup = "Road (Truck)";
        public const string TrainGroup = "Train";
        public const string ShipGroup = "Ship";
        public const string AirGroup = "Air";
        public const string ControlGroup2 = "Cargo Bulk Options";
        public const string Free2 = "Make Cargo Free";
        public const string Reset2 = "Reset Cargo Costs to Vanilla";

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

        private string CalculatedText(double fee, double vanillaDataFee)
        {
            double calc = Math.Ceiling(PopulationValue / PopulationMultiplier) * PopulationMultiplier * (fee * vanillaDataFee / 100d);
            
            return $"₵ { calc.ToString("N0") } per month";
        }

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

        [SettingsUIHidden]
        [Exclude]
        public double PopulationValue { get; set; }


        [SettingsUIHidden]
        [Exclude]
        public bool NotGameMode { get; set; }

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float PoliceFee { get; set; }
        [SettingsUIHideByCondition(typeof(Setting), nameof(NotGameMode))]
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string PoliceFeeValue => CalculatedText(PoliceFee, VanillaData.PoliceFee);

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float AmbulanceFee { get; set; }
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string AmbulanceFeeValue => CalculatedText(AmbulanceFee, VanillaData.AmbulanceFee);

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float HearseFee { get; set; }
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string HearseFeeValue => CalculatedText(HearseFee, VanillaData.HearseFee);

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float FireEngineFee { get; set; }
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string FireEngineFeeValue => CalculatedText(FireEngineFee, VanillaData.FireEngineFee);

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float GarbageFee { get; set; }
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string GarbageFeeValue => CalculatedText(GarbageFee, VanillaData.GarbageFee);


        [SettingsUISection(ServiceTab, ControlGroup1)]
        [SettingsUIButton]
        public bool FreeButton1 { set { MakeFree1(); } }

        [SettingsUISection(ServiceTab, ControlGroup1)]
        [SettingsUIButton]
        public bool ResetButton1 { set { SetDefaults1(); } }


        [SettingsUISection(CargoTab, RoadGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float RoadWeightMultiplier { get; set; }

        [SettingsUISection(CargoTab, RoadGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float RoadDistanceMultiplier { get; set; }
        [SettingsUISection(CargoTab, RoadGroup)]
        public string RoadValue => $"{(RoadWeightMultiplier * VanillaData.RoadWeightMultiplier).ToString("N2")} × tonne + {(RoadDistanceMultiplier * VanillaData.RoadDistanceMultiplier).ToString("N2")} × km";

        [SettingsUISection(CargoTab, TrainGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float TrainWeightMultiplier { get; set; }

        [SettingsUISection(CargoTab, TrainGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float TrainDistanceMultiplier { get; set; }
        [SettingsUISection(CargoTab, TrainGroup)]
        public string TrainValue => $"{(TrainWeightMultiplier * VanillaData.TrainWeightMultiplier).ToString("N2")} × tonne + {(TrainDistanceMultiplier * VanillaData.TrainDistanceMultiplier).ToString("N2")} × km";

        [SettingsUISection(CargoTab, ShipGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float ShipWeightMultiplier { get; set; }

        [SettingsUISection(CargoTab, ShipGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float ShipDistanceMultiplier { get; set; }
        [SettingsUISection(CargoTab, ShipGroup)]
        public string ShipValue => $"{(ShipWeightMultiplier * VanillaData.ShipWeightMultiplier).ToString("N2")} × tonne + {(ShipDistanceMultiplier * VanillaData.ShipDistanceMultiplier).ToString("N2")} × km";

        [SettingsUISection(CargoTab, AirGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float AirWeightMultiplier { get; set; }

        [SettingsUISection(CargoTab, AirGroup)]
        [SettingsUISlider(min = 0, max = 500, step = 10, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public float AirDistanceMultiplier { get; set; }
        [SettingsUISection(CargoTab, AirGroup)]
        public string AirValue => $"{(AirWeightMultiplier * VanillaData.AirWeightMultiplier).ToString("N2")} × kg + {(AirDistanceMultiplier * VanillaData.AirDistanceMultiplier).ToString("N2")} × km";

        [SettingsUISection(CargoTab, ControlGroup2)]
        [SettingsUIButton]
        public bool FreeButton2 { set { MakeFree2(); } }

        [SettingsUISection(CargoTab, ControlGroup2)]
        [SettingsUIButton]
        public bool ResetButton2 { set { SetDefaults2(); } }


        [SettingsUISection(AboutTab, InfoGroup)]
        public string NameText => Mod.Name;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string VersionText => Mod.Version;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string AuthorText => Mod.Author;

        public override void SetDefaults()
        {
            SetDefaults1();
            SetDefaults2();
        }

        public void SetDefaults1()
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
        }
        public void SetDefaults2()
        {
            PopulationMultiplier = 1000;
            RoadWeightMultiplier = 100;
            RoadDistanceMultiplier = 100;
            TrainWeightMultiplier = 100;
            TrainDistanceMultiplier = 100;
            ShipWeightMultiplier = 100;
            ShipDistanceMultiplier = 100;
            AirWeightMultiplier = 100;
            AirDistanceMultiplier = 100;
        }
        public void MakeFree1()
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
        }
        public void MakeFree2()
        {
            PopulationMultiplier = 1000;
            RoadWeightMultiplier = 0;
            RoadDistanceMultiplier = 0;
            TrainWeightMultiplier = 0;
            TrainDistanceMultiplier = 0;
            ShipWeightMultiplier = 0;
            ShipDistanceMultiplier = 0;
            AirWeightMultiplier = 0;
            AirDistanceMultiplier = 0;
        }
    }
}
