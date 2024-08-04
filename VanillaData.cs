namespace TradingCostTweaker
{
    public class VanillaData
    {
        public float ElectricityImportPrice { get; }
        public float ElectricityExportPrice { get; }
        public float WaterImportPrice { get; }
        public float WaterExportPrice { get; }
        public float WaterExportPollutionTolerance { get; }
        public float SewageExportPrice { get; }
        public int PopulationMultiplier { get; }
        public int GarbageFee { get; }
        public int AmbulanceFee { get; }
        public int HearseFee { get; }
        public int FireEngineFee { get; }
        public int PoliceFee { get; }
        public float RoadDistanceMultiplier { get; }
        public float RoadWeightMultiplier { get; }
        public float AirDistanceMultiplier { get; }
        public float AirWeightMultiplier { get; }
        public float ShipDistanceMultiplier { get; }
        public float ShipWeightMultiplier { get; }
        public float TrainDistanceMultiplier { get; }
        public float TrainWeightMultiplier { get; }

        public VanillaData()
        {
            ElectricityImportPrice = 1.00f;
            ElectricityExportPrice = 0.25f;
            WaterImportPrice = 0.1f;
            WaterExportPrice = 0.05f;
            WaterExportPollutionTolerance = 0.1f;
            SewageExportPrice = 0.1f;
            PopulationMultiplier = 1000;
            GarbageFee = 5;
            AmbulanceFee = 25;
            HearseFee = 25;
            FireEngineFee = 50;
            PoliceFee = 50;
            RoadDistanceMultiplier = 0.04f;
            RoadWeightMultiplier = 0.02f;
            AirDistanceMultiplier = 0.001f;
            AirWeightMultiplier = 0.05f;
            ShipDistanceMultiplier = 0.001f;
            ShipWeightMultiplier = 0.005f;
            TrainDistanceMultiplier = 0.01f;
            TrainWeightMultiplier = 0.005f;
        }
    }
}
