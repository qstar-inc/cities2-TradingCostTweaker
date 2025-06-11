using System.Collections.Generic;
using Colossal;
using Colossal.Json;
using TradingCostTweaker.Systems;

namespace TradingCostTweaker
{
    public class LocaleEN : IDictionarySource
    {
        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        private readonly Setting m_Setting;
        private static VanillaData VanillaDataFromStorage => VanillaDataStorage.VanillaData;

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts
        )
        {
            static string Default(string value) => $"\r\n- Default: <{value}>";
            string CargoValueDesc =
                "\r\n- Setting the Multiplier values high for a single transportation method will make companies look for alternate methods or sources preferably within the city.";

            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), Mod.Name },
                { m_Setting.GetOptionTabLocaleID(Setting.ServiceTab), Setting.ServiceTab },
                { m_Setting.GetOptionTabLocaleID(Setting.CargoTab), Setting.CargoTab },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), Setting.AboutTab },
                { m_Setting.GetOptionGroupLocaleID(Setting.WaterGroup), Setting.WaterGroup },
                {
                    m_Setting.GetOptionGroupLocaleID(Setting.ElectricityGroup),
                    Setting.ElectricityGroup
                },
                {
                    m_Setting.GetOptionGroupLocaleID(Setting.OtherServiceGroup),
                    Setting.OtherServiceGroup
                },
                { m_Setting.GetOptionGroupLocaleID(Setting.ControlGroup1), Setting.ControlGroup1 },
                { m_Setting.GetOptionGroupLocaleID(Setting.RoadGroup), Setting.RoadGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrainGroup), Setting.TrainGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.ShipGroup), Setting.ShipGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.AirGroup), Setting.AirGroup },
                { m_Setting.GetOptionGroupLocaleID(Setting.ControlGroup2), Setting.ControlGroup2 },
                { m_Setting.GetOptionGroupLocaleID(Setting.InfoGroup), Setting.InfoGroup },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElectricityImportPrice)),
                    "Electricity Import Price"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElectricityImportPrice)),
                    $"The percentage value to alter the electricity import fees. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElectricityImportPriceValue)),
                    "Current Electricity Import Fees"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElectricityImportPriceValue)),
                    $"The amount paid for importing each kW of electricity for 24 hours. {Default($"{VanillaDataFromStorage.m_ElectricityImportPrice.ToJSONString()}")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElectricityExportPrice)),
                    "Electricity Export Price"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElectricityExportPrice)),
                    $"The percentage value to alter the electricity export fees. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ElectricityExportPriceValue)),
                    "Current Electricity Export Fees"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ElectricityExportPriceValue)),
                    $"The amount paid for exporting each kW of electricity for 24 hours. {Default($"{10f * VanillaDataFromStorage.m_ElectricityExportPrice}")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.WaterImportPrice)),
                    "Water Import Price"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WaterImportPrice)),
                    $"The percentage value to alter the water import fees. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.WaterImportPriceValue)),
                    "Current Water Import Fees"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WaterImportPriceValue)),
                    $"The amount paid for importing each 100m³ of water for 24 hours. {Default($"{100f * VanillaDataFromStorage.m_WaterImportPrice}")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.WaterExportPrice)),
                    "Water Export Price"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WaterExportPrice)),
                    $"The percentage value to alter the water export fees. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.WaterExportPriceValue)),
                    "Current Water Export Fees"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WaterExportPriceValue)),
                    $"The amount received for exporting each 100m³ of water for 24 hours. {Default($"{100f * VanillaDataFromStorage.m_WaterExportPrice}")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.WaterExportPollutionTolerance)),
                    "Water Export Pollution Tolerance"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WaterExportPollutionTolerance)),
                    $"The percentage of water pollution at which the water export price will become zero. {Default($"{100f * VanillaDataFromStorage.m_WaterExportPollutionTolerance}")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.SewageExportPrice)),
                    "Sewage Export Price"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.SewageExportPrice)),
                    $"The percentage value to alter the sewage export fees. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.SewageExportPriceValue)),
                    "Current Sewage Export Fees"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.SewageExportPriceValue)),
                    $"The amount paid for exporting each 100m³ of water for 24 hours. {Default($"{100f * VanillaDataFromStorage.m_SewageExportPrice}")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PopulationMultiplier)),
                    "Population Multiplier"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PopulationMultiplier)),
                    $"The population multiplier for the sevice fees. {Default($"{VanillaDataFromStorage.m_OCServiceTradePopulationRange}")}\r\n- This means all service fee will increase for each {VanillaDataFromStorage.m_OCServiceTradePopulationRange} population)"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceFee)), "Police Fee" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PoliceFee)),
                    $"The percentage value to alter the service fee paid for Police service import per population multiplier. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.PoliceFeeValue)),
                    "Imported Police Service Fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.PoliceFeeValue)),
                    $"The service fee paid for Police service import per population multiplier. (Default: 50,000 for each 1000 population)"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceFee)),
                    "Healthcare Fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AmbulanceFee)),
                    $"The percentage value to alter the service fee paid for Ambulance service import per population multiplier. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceFeeValue)),
                    "Imported Healthcare Service Fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AmbulanceFeeValue)),
                    $"The service fee paid for Ambulance service import per population multiplier. (Default: 25,000 for each 1000 population)"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseFee)), "Deathcare Fee" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HearseFee)),
                    $"The percentage value to alter the service fee paid for Hearse service import per population multiplier. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.HearseFeeValue)),
                    "Imported Deathcare Service Fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HearseFeeValue)),
                    $"The service fee paid for Hearse service import per population multiplier. (Default: 25,000 for each 1000 population)"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineFee)),
                    "Fire & Rescue Fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FireEngineFee)),
                    $"The percentage value to alter the service fee paid for Fire Engine service import per population multiplier. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineFeeValue)),
                    "Imported Fire & Rescue Service Fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FireEngineFeeValue)),
                    $"The service fee paid for Fire Engine service import per population multiplier. (Default: 50,000 for each 1000 population)"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFee)),
                    "Garbage Management Fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFee)),
                    $"The percentage value to alter the service fee paid for Garbage service import per population multiplier. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFeeValue)),
                    "Imported Garbage Management Service Fee"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFeeValue)),
                    $"The service fee paid for Garbage service import per population multiplier. (Default: 5,000 for each 1000 population)"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FreeButton1)), Setting.Free1 },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FreeButton1)),
                    "Set all service costs to 0%."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetButton1)), Setting.Reset1 },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetButton1)),
                    "Resets all service costs to 100%."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadWeightMultiplier)),
                    "Road Weight Multiplier"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadWeightMultiplier)),
                    $"The percentage value to alter the road cargo cost based on the weight. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadDistanceMultiplier)),
                    "Road Distance Multiplier"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadDistanceMultiplier)),
                    $"The percentage value to alter the road cargo cost based on the distance. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadValue)),
                    "Current Road Multipliers"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadValue)),
                    $"Current Road Multipliers {CargoValueDesc}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainWeightMultiplier)),
                    "Train Weight Multiplier"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainWeightMultiplier)),
                    $"The percentage value to alter the train cargo cost based on the weight. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainDistanceMultiplier)),
                    "Train Distance Multiplier"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainDistanceMultiplier)),
                    $"The percentage value to alter the train cargo cost based on the distance. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrainValue)),
                    "Current Train Multipliers"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TrainValue)),
                    $"Current Train Multipliers {CargoValueDesc}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipWeightMultiplier)),
                    "Ship Weight Multiplier"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipWeightMultiplier)),
                    $"The percentage value to alter the ship cargo cost based on the weight. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipDistanceMultiplier)),
                    "Ship Distance Multiplier"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipDistanceMultiplier)),
                    $"The percentage value to alter the ship cargo cost based on the distance. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ShipValue)),
                    "Current Ship Multipliers"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ShipValue)),
                    $"Current Ship Multipliers {CargoValueDesc}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirWeightMultiplier)),
                    "Air Weight Multiplier"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AirWeightMultiplier)),
                    $"The percentage value to alter the air cargo cost based on the weight. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirDistanceMultiplier)),
                    "Air Distance Multiplier"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AirDistanceMultiplier)),
                    $"The percentage value to alter the air cargo cost based on the distance. {Default("100%")}"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AirValue)),
                    "Current Air Multipliers"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AirValue)),
                    $"Current Air Multipliers {CargoValueDesc}"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FreeButton2)), Setting.Free2 },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.FreeButton2)),
                    "Set all cargo costs to 0%."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetButton2)), Setting.Reset2 },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetButton2)),
                    "Resets all cargo costs to 100%."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod Name" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Mod Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AuthorText)), "Author" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AuthorText)), "" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.BMaCLink)), "Buy Me a Coffee" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.BMaCLink)),
                    "Support the author."
                },
            };
        }

        public void Unload() { }
    }
}
