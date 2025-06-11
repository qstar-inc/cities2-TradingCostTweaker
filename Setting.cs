using System;
using System.Collections.Generic;
using Colossal.IO.AssetDatabase;
using Colossal.Json;
using Game.Modding;
using Game.Settings;
using Game.UI;
using TradingCostTweaker.Systems;
using UnityEngine.Device;

namespace TradingCostTweaker
{
    [FileLocation("ModsSettings\\StarQ\\" + nameof(TradingCostTweaker))]
    [SettingsUITabOrder(ServiceTab, CargoTab, AboutTab)]
    [SettingsUIGroupOrder(
        ElectricityGroup,
        WaterGroup,
        OtherServiceGroup,
        ControlGroup1,
        RoadGroup,
        TrainGroup,
        ShipGroup,
        AirGroup,
        ControlGroup2,
        InfoGroup
    )]
    [SettingsUIShowGroupName(
        ElectricityGroup,
        WaterGroup,
        OtherServiceGroup,
        ControlGroup1,
        RoadGroup,
        TrainGroup,
        ShipGroup,
        AirGroup,
        ControlGroup2
    )]
    public class Setting : ModSetting
    {
        public Setting(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        private readonly Dictionary<string, object> _values = new();

        private T GetValue<T>(string propertyName, T defaultValue = default)
        {
            if (_values.TryGetValue(propertyName, out var value))
            {
                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch (InvalidCastException)
                {
                    Mod.log.Info(
                        $"Warning: Unable to cast setting '{propertyName}' to {typeof(T)}. Returning default."
                    );
                }
            }
            return defaultValue;
        }

        private void SetValue<T>(string propertyName, T value, Action onChanged = null)
        {
            _values[propertyName] = value;
            onChanged?.Invoke();
        }

        [Exclude]
        public VanillaData VanillaDataFromStorage = new();

        //private readonly OutsideTradeSystem outsideTradeSystem = new();

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

        //public const string ResourceTab = "Resource";
        //public const string ConvenienceFood = "ConvenienceFood";
        //public const string
        //public const string

        public const string AboutTab = "About";
        public const string InfoGroup = "Info";

        private string TextMaker(string value, string type, string pop = null)
        {
            string unit = type switch
            {
                "electricity" => " per kW",
                "water" => " per 100m³",
                _ => $" per {pop} citizens",
            };
            return $"₵ {value}{unit} per month";
        }

        private string CalculatedText(double fee, double vanillaDataFee)
        {
            double calc =
                Math.Ceiling(PopulationValue / PopulationMultiplier)
                * PopulationMultiplier
                * (fee * vanillaDataFee / 100d);

            return $"₵ {calc:N0} per month";
        }

        [SettingsUISection(ServiceTab, ElectricityGroup)]
        [SettingsUISlider(
            min = 0,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public int ElectricityImportPrice
        {
            get => GetValue(nameof(ElectricityImportPrice), 100);
            set => SetValue(nameof(ElectricityImportPrice), value, ApplyChanges);
        }

        [SettingsUISection(ServiceTab, ElectricityGroup)]
        public string ElectricityImportPriceValue =>
            TextMaker(
                (
                    ElectricityImportPrice * VanillaDataFromStorage.m_ElectricityImportPrice / 10
                ).ToString(),
                "electricity"
            );

        [SettingsUISection(ServiceTab, ElectricityGroup)]
        [SettingsUISlider(
            min = 0,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public int ElectricityExportPrice
        {
            get => GetValue(nameof(ElectricityExportPrice), 100);
            set => SetValue(nameof(ElectricityExportPrice), value, ApplyChanges);
        }

        [SettingsUISection(ServiceTab, ElectricityGroup)]
        public string ElectricityExportPriceValue =>
            TextMaker(
                (
                    ElectricityExportPrice * VanillaDataFromStorage.m_ElectricityExportPrice / 10
                ).ToString(),
                "electricity"
            );

        [SettingsUISection(ServiceTab, WaterGroup)]
        [SettingsUISlider(
            min = 0,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public int WaterImportPrice
        {
            get => GetValue(nameof(WaterImportPrice), 100);
            set => SetValue(nameof(WaterImportPrice), value, ApplyChanges);
        }

        [SettingsUISection(ServiceTab, WaterGroup)]
        public string WaterImportPriceValue =>
            TextMaker(
                (WaterImportPrice * VanillaDataFromStorage.m_WaterImportPrice).ToString(),
                "water"
            );

        [SettingsUISection(ServiceTab, WaterGroup)]
        [SettingsUISlider(
            min = 0,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public int WaterExportPrice
        {
            get => GetValue(nameof(WaterExportPrice), 100);
            set => SetValue(nameof(WaterExportPrice), value, ApplyChanges);
        }

        [SettingsUISection(ServiceTab, WaterGroup)]
        public string WaterExportPriceValue =>
            TextMaker(
                (WaterExportPrice * VanillaDataFromStorage.m_WaterExportPrice).ToString(),
                "water"
            );

        [SettingsUISection(ServiceTab, WaterGroup)]
        [SettingsUISlider(
            min = 0,
            max = 100,
            step = 5,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public int WaterExportPollutionTolerance
        {
            get => GetValue(nameof(WaterExportPollutionTolerance), 100);
            set => SetValue(nameof(WaterExportPollutionTolerance), value, ApplyChanges);
        }

        [SettingsUISection(ServiceTab, WaterGroup)]
        [SettingsUISlider(
            min = 0,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public int SewageExportPrice
        {
            get => GetValue(nameof(SewageExportPrice), 100);
            set => SetValue(nameof(SewageExportPrice), value, ApplyChanges);
        }

        [SettingsUISection(ServiceTab, WaterGroup)]
        public string SewageExportPriceValue =>
            TextMaker(
                (SewageExportPrice * VanillaDataFromStorage.m_SewageExportPrice).ToString(),
                "water"
            );

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(
            min = 1000,
            max = 10000,
            step = 500,
            scalarMultiplier = 1,
            unit = Unit.kInteger
        )]
        public int PopulationMultiplier
        {
            get => GetValue(nameof(PopulationMultiplier), 100);
            set => SetValue(nameof(PopulationMultiplier), value, ApplyChanges);
        }

        [SettingsUIHidden]
        [Exclude]
        public double PopulationValue { get; set; }

        [SettingsUIHidden]
        [Exclude]
        public bool NotGameMode { get; set; }

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public int PoliceFee
        {
            get => GetValue(nameof(PoliceFee), 100);
            set => SetValue(nameof(PoliceFee), value, ApplyChanges);
        }

        [SettingsUIHideByCondition(typeof(Setting), nameof(NotGameMode))]
        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string PoliceFeeValue =>
            CalculatedText(PoliceFee, VanillaDataFromStorage.m_PoliceImportServiceFee);

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float AmbulanceFee
        {
            get => GetValue(nameof(AmbulanceFee), 100);
            set => SetValue(nameof(AmbulanceFee), value, ApplyChanges);
        }

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string AmbulanceFeeValue =>
            CalculatedText(AmbulanceFee, VanillaDataFromStorage.m_AmbulanceImportServiceFee);

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float HearseFee
        {
            get => GetValue(nameof(HearseFee), 100);
            set => SetValue(nameof(HearseFee), value, ApplyChanges);
        }

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string HearseFeeValue =>
            CalculatedText(HearseFee, VanillaDataFromStorage.m_HearseImportServiceFee);

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float FireEngineFee
        {
            get => GetValue(nameof(FireEngineFee), 100);
            set => SetValue(nameof(FireEngineFee), value, ApplyChanges);
        }

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string FireEngineFeeValue =>
            CalculatedText(FireEngineFee, VanillaDataFromStorage.m_FireEngineImportServiceFee);

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float GarbageFee
        {
            get => GetValue(nameof(GarbageFee), 100);
            set => SetValue(nameof(GarbageFee), value, ApplyChanges);
        }

        [SettingsUISection(ServiceTab, OtherServiceGroup)]
        public string GarbageFeeValue =>
            CalculatedText(GarbageFee, VanillaDataFromStorage.m_GarbageImportServiceFee);

        [SettingsUISection(ServiceTab, ControlGroup1)]
        [SettingsUIButton]
        public bool FreeButton1
        {
            set { MakeFree1(); }
        }

        [SettingsUISection(ServiceTab, ControlGroup1)]
        [SettingsUIButton]
        public bool ResetButton1
        {
            set { SetDefaults1(); }
        }

        [SettingsUISection(CargoTab, RoadGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float RoadWeightMultiplier
        {
            get => GetValue(nameof(RoadWeightMultiplier), 100);
            set => SetValue(nameof(RoadWeightMultiplier), value, ApplyChanges);
        }

        [SettingsUISection(CargoTab, RoadGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float RoadDistanceMultiplier
        {
            get => GetValue(nameof(RoadDistanceMultiplier), 100);
            set => SetValue(nameof(RoadDistanceMultiplier), value, ApplyChanges);
        }

        [SettingsUISection(CargoTab, RoadGroup)]
        public string RoadValue =>
            $"{RoadWeightMultiplier * VanillaDataFromStorage.m_RoadWeightMultiplier:N2} × tonne + {RoadDistanceMultiplier * VanillaDataFromStorage.m_RoadDistanceMultiplier:N2} × km";

        [SettingsUISection(CargoTab, TrainGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float TrainWeightMultiplier
        {
            get => GetValue(nameof(TrainWeightMultiplier), 100);
            set => SetValue(nameof(TrainWeightMultiplier), value, ApplyChanges);
        }

        [SettingsUISection(CargoTab, TrainGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float TrainDistanceMultiplier
        {
            get => GetValue(nameof(TrainDistanceMultiplier), 100);
            set => SetValue(nameof(TrainDistanceMultiplier), value, ApplyChanges);
        }

        [SettingsUISection(CargoTab, TrainGroup)]
        public string TrainValue =>
            $"{TrainWeightMultiplier * VanillaDataFromStorage.m_TrainWeightMultiplier:N2} × tonne + {TrainDistanceMultiplier * VanillaDataFromStorage.m_TrainDistanceMultiplier:N2} × km";

        [SettingsUISection(CargoTab, ShipGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float ShipWeightMultiplier
        {
            get => GetValue(nameof(ShipWeightMultiplier), 100);
            set => SetValue(nameof(ShipWeightMultiplier), value, ApplyChanges);
        }

        [SettingsUISection(CargoTab, ShipGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float ShipDistanceMultiplier
        {
            get => GetValue(nameof(ShipDistanceMultiplier), 100);
            set => SetValue(nameof(ShipDistanceMultiplier), value, ApplyChanges);
        }

        [SettingsUISection(CargoTab, ShipGroup)]
        public string ShipValue =>
            $"{ShipWeightMultiplier * VanillaDataFromStorage.m_ShipWeightMultiplier:N2} × tonne + {ShipDistanceMultiplier * VanillaDataFromStorage.m_ShipDistanceMultiplier:N2} × km";

        [SettingsUISection(CargoTab, AirGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float AirWeightMultiplier
        {
            get => GetValue(nameof(AirWeightMultiplier), 100);
            set => SetValue(nameof(AirWeightMultiplier), value, ApplyChanges);
        }

        [SettingsUISection(CargoTab, AirGroup)]
        [SettingsUISlider(
            min = -50,
            max = 500,
            step = 10,
            scalarMultiplier = 1,
            unit = Unit.kPercentage
        )]
        public float AirDistanceMultiplier
        {
            get => GetValue(nameof(AirDistanceMultiplier), 100);
            set => SetValue(nameof(AirDistanceMultiplier), value, ApplyChanges);
        }

        [SettingsUISection(CargoTab, AirGroup)]
        public string AirValue =>
            $"{AirWeightMultiplier * VanillaDataFromStorage.m_AirWeightMultiplier:N2} × kg + {AirDistanceMultiplier * VanillaDataFromStorage.m_AirDistanceMultiplier:N2} × km";

        [SettingsUISection(CargoTab, ControlGroup2)]
        [SettingsUIButton]
        public bool FreeButton2
        {
            set { MakeFree2(); }
        }

        [SettingsUISection(CargoTab, ControlGroup2)]
        [SettingsUIButton]
        public bool ResetButton2
        {
            set { SetDefaults2(); }
        }

        [SettingsUISection(AboutTab, InfoGroup)]
        public string NameText => Mod.Name;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string VersionText => Mod.Version;

        [SettingsUISection(AboutTab, InfoGroup)]
        public string AuthorText => "StarQ";

        [SettingsUIButtonGroup("Social")]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, InfoGroup)]
        public bool BMaCLink
        {
            set
            {
                try
                {
                    Application.OpenURL($"https://buymeacoffee.com/starq");
                }
                catch (Exception e)
                {
                    Mod.log.Info(e);
                }
            }
        }

        [Exclude]
        public bool Changes = false;

        public void ApplyChanges()
        {
            Changes = true;
        }

        public override void SetDefaults()
        {
            Changes = false;
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
