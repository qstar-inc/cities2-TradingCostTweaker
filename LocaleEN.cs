﻿using Colossal;
using System.Collections.Generic;

namespace TradingCostTweaker
{
    public class LocaleEN(Setting setting) : IDictionarySource
    {
        public const string CargoValueDesc = "Setting the Multiplier values high for a single transportation method will make companies look for alternate methods or sources preferably within the city.";
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { setting.GetSettingsLocaleID(), Mod.Name },
                { setting.GetOptionTabLocaleID(Setting.ServiceTab), Setting.ServiceTab },
                { setting.GetOptionTabLocaleID(Setting.CargoTab), Setting.CargoTab },
                { setting.GetOptionTabLocaleID(Setting.AboutTab), Setting.AboutTab },

                { setting.GetOptionGroupLocaleID(Setting.WaterGroup), Setting.WaterGroup },
                { setting.GetOptionGroupLocaleID(Setting.ElectricityGroup), Setting.ElectricityGroup },
                { setting.GetOptionGroupLocaleID(Setting.OtherServiceGroup), Setting.OtherServiceGroup },
                { setting.GetOptionGroupLocaleID(Setting.ControlGroup1), Setting.ControlGroup1 },

                { setting.GetOptionGroupLocaleID(Setting.RoadGroup), Setting.RoadGroup },
                { setting.GetOptionGroupLocaleID(Setting.TrainGroup), Setting.TrainGroup },
                { setting.GetOptionGroupLocaleID(Setting.ShipGroup), Setting.ShipGroup },
                { setting.GetOptionGroupLocaleID(Setting.AirGroup), Setting.AirGroup },
                { setting.GetOptionGroupLocaleID(Setting.ControlGroup2), Setting.ControlGroup2 },

                { setting.GetOptionGroupLocaleID(Setting.InfoGroup), Setting.InfoGroup },

                { setting.GetOptionLabelLocaleID(nameof(Setting.ElectricityImportPrice)), "Electricity Import Price" },
                { setting.GetOptionDescLocaleID(nameof(Setting.ElectricityImportPrice)), "The percentage value to alter the electricity import fees." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.ElectricityImportPriceValue)), "Current Electricity Import Fees" },
                { setting.GetOptionDescLocaleID(nameof(Setting.ElectricityImportPriceValue)), "The amount paid for importing each kW of electricity for 24 hours. (Default: 10)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.ElectricityExportPrice)), "Electricity Export Price" },
                { setting.GetOptionDescLocaleID(nameof(Setting.ElectricityExportPrice)), "The percentage value to alter the electricity export fees." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.ElectricityExportPriceValue)), "Current Electricity Export Fees" },
                { setting.GetOptionDescLocaleID(nameof(Setting.ElectricityExportPriceValue)), "The amount paid for exporting each kW of electricity for 24 hours. (Default: 2.5)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.WaterImportPrice)), "Water Import Price" },
                { setting.GetOptionDescLocaleID(nameof(Setting.WaterImportPrice)), "The percentage value to alter the water import fees." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.WaterImportPriceValue)), "Current Water Import Fees" },
                { setting.GetOptionDescLocaleID(nameof(Setting.WaterImportPriceValue)), "The amount paid for importing each 100m³ of water for 24 hours. (Default: 10)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.WaterExportPrice)), "Water Export Price" },
                { setting.GetOptionDescLocaleID(nameof(Setting.WaterExportPrice)), "The percentage value to alter the water export fees." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.WaterExportPriceValue)), "Current Water Export Fees" },
                { setting.GetOptionDescLocaleID(nameof(Setting.WaterExportPriceValue)), "The amount received for exporting each 100m³ of water for 24 hours. (Default: 5)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.WaterExportPollutionTolerance)), "Water Export Pollution Tolerance" },
                { setting.GetOptionDescLocaleID(nameof(Setting.WaterExportPollutionTolerance)), "The percentage of water pollution at which the water export price will become zero. (Default: 10%)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.SewageExportPrice)), "Sewage Export Price" },
                { setting.GetOptionDescLocaleID(nameof(Setting.SewageExportPrice)), "The percentage value to alter the sewage export fees." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.SewageExportPriceValue)), "Current Sewage Export Fees" },
                { setting.GetOptionDescLocaleID(nameof(Setting.SewageExportPriceValue)), "The amount paid for exporting each 100m³ of water for 24 hours. (Default: 10)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.PopulationMultiplier)), "Population Multiplier" },
                { setting.GetOptionDescLocaleID(nameof(Setting.PopulationMultiplier)), "The population multiplier for the sevice fees. (Default: 1000, this means all service fee will increase for each 1000 population.)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.PoliceFee)), "Police Fee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.PoliceFee)), "The percentage value to alter the service fee paid for Police service import per population multiplier." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.PoliceFeeValue)), "Imported Police Service Fee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.PoliceFeeValue)), "The service fee paid for Police service import per population multiplier. (Default: 50,000 for each 1000 population)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceFee)), "Healthcare Fee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AmbulanceFee)), "The percentage value to alter the service fee paid for Ambulance service import per population multiplier." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AmbulanceFeeValue)), "Imported Healthcare Service Fee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AmbulanceFeeValue)), "The service fee paid for Ambulance service import per population multiplier. (Default: 25,000 for each 1000 population)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.HearseFee)), "Deathcare Fee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.HearseFee)), "The percentage value to alter the service fee paid for Hearse service import per population multiplier." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.HearseFeeValue)), "Imported Deathcare Service Fee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.HearseFeeValue)), "The service fee paid for Hearse service import per population multiplier. (Default: 25,000 for each 1000 population)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineFee)), "Fire & Rescue Fee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.FireEngineFee)), "The percentage value to alter the service fee paid for Fire Engine service import per population multiplier." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.FireEngineFeeValue)), "Imported Fire & Rescue Service Fee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.FireEngineFeeValue)), "The service fee paid for Fire Engine service import per population multiplier. (Default: 50,000 for each 1000 population)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFee)), "Garbage Management Fee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.GarbageFee)), "The percentage value to alter the service fee paid for Garbage service import per population multiplier." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFeeValue)), "Imported Garbage Management Service Fee" },
                { setting.GetOptionDescLocaleID(nameof(Setting.GarbageFeeValue)), "The service fee paid for Garbage service import per population multiplier. (Default: 5,000 for each 1000 population)" },

                { setting.GetOptionLabelLocaleID(nameof(Setting.FreeButton1)), Setting.Free1 },
                { setting.GetOptionDescLocaleID(nameof(Setting.FreeButton1)), "Set all service costs to 0%." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.ResetButton1)), Setting.Reset1 },
                { setting.GetOptionDescLocaleID(nameof(Setting.ResetButton1)), "Resets all service costs to 100%." },

                { setting.GetOptionLabelLocaleID(nameof(Setting.RoadWeightMultiplier)), "Road Weight Multiplier" },
                { setting.GetOptionDescLocaleID(nameof(Setting.RoadWeightMultiplier)), "The percentage value to alter the road cargo cost based on the weight." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.RoadDistanceMultiplier)), "Road Distance Multiplier" },
                { setting.GetOptionDescLocaleID(nameof(Setting.RoadDistanceMultiplier)), "The percentage value to alter the road cargo cost based on the distance." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.RoadValue)), "Current Road Multipliers" },
                { setting.GetOptionDescLocaleID(nameof(Setting.RoadValue)), CargoValueDesc },

                { setting.GetOptionLabelLocaleID(nameof(Setting.TrainWeightMultiplier)), "Train Weight Multiplier" },
                { setting.GetOptionDescLocaleID(nameof(Setting.TrainWeightMultiplier)), "The percentage value to alter the train cargo cost based on the weight." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.TrainDistanceMultiplier)), "Train Distance Multiplier" },
                { setting.GetOptionDescLocaleID(nameof(Setting.TrainDistanceMultiplier)), "The percentage value to alter the train cargo cost based on the distance." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.TrainValue)), "Current Train Multipliers" },
                { setting.GetOptionDescLocaleID(nameof(Setting.TrainValue)), CargoValueDesc },

                { setting.GetOptionLabelLocaleID(nameof(Setting.ShipWeightMultiplier)), "Ship Weight Multiplier" },
                { setting.GetOptionDescLocaleID(nameof(Setting.ShipWeightMultiplier)), "The percentage value to alter the ship cargo cost based on the weight." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.ShipDistanceMultiplier)), "Ship Distance Multiplier" },
                { setting.GetOptionDescLocaleID(nameof(Setting.ShipDistanceMultiplier)), "The percentage value to alter the ship cargo cost based on the distance." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.ShipValue)), "Current Ship Multipliers" },
                { setting.GetOptionDescLocaleID(nameof(Setting.ShipValue)), CargoValueDesc },

                { setting.GetOptionLabelLocaleID(nameof(Setting.AirWeightMultiplier)), "Air Weight Multiplier" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AirWeightMultiplier)), "The percentage value to alter the air cargo cost based on the weight." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AirDistanceMultiplier)), "Air Distance Multiplier" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AirDistanceMultiplier)), "The percentage value to alter the air cargo cost based on the distance." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AirValue)), "Current Air Multipliers" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AirValue)), CargoValueDesc },

                { setting.GetOptionLabelLocaleID(nameof(Setting.FreeButton2)), Setting.Free2 },
                { setting.GetOptionDescLocaleID(nameof(Setting.FreeButton2)), "Set all cargo costs to 0%." },
                { setting.GetOptionLabelLocaleID(nameof(Setting.ResetButton2)), Setting.Reset2 },
                { setting.GetOptionDescLocaleID(nameof(Setting.ResetButton2)), "Resets all cargo costs to 100%." },

                { setting.GetOptionLabelLocaleID(nameof(Setting.NameText)), "Mod Name" },
                { setting.GetOptionDescLocaleID(nameof(Setting.NameText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.VersionText)), "Mod Version" },
                { setting.GetOptionDescLocaleID(nameof(Setting.VersionText)), "" },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AuthorText)), "Author" },
                { setting.GetOptionDescLocaleID(nameof(Setting.AuthorText)), "" },

            };
        }

        public void Unload()
        {

        }
    }
}
