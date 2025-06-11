using Colossal.Collections;
using Colossal.Entities;
using Colossal.Json;
using Game;
using Game.Prefabs;
using Game.SceneFlow;
using Unity.Collections;
using Unity.Entities;

namespace TradingCostTweaker.Systems
{
    public static class VanillaDataStorage
    {
        public static VanillaData VanillaData { get; set; } = new VanillaData();
    }

    public struct VanillaData
    {
        public float m_ElectricityImportPrice;
        public float m_ElectricityExportPrice;
        public float m_WaterImportPrice;
        public float m_WaterExportPrice;
        public float m_WaterExportPollutionTolerance;
        public float m_SewageExportPrice;
        public float m_AirWeightMultiplier;
        public float m_RoadWeightMultiplier;
        public float m_TrainWeightMultiplier;
        public float m_ShipWeightMultiplier;
        public float m_AirDistanceMultiplier;
        public float m_RoadDistanceMultiplier;
        public float m_TrainDistanceMultiplier;
        public float m_ShipDistanceMultiplier;
        public float m_AmbulanceImportServiceFee;
        public float m_HearseImportServiceFee;
        public float m_FireEngineImportServiceFee;
        public float m_GarbageImportServiceFee;
        public float m_PoliceImportServiceFee;
        public int m_OCServiceTradePopulationRange;
    }

    public partial class VanillaDataSystem : GameSystemBase
    {
        private PrefabSystem prefabSystem;
        private EntityQuery prefabQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            prefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            prefabQuery = SystemAPI.QueryBuilder().WithAll<OutsideTradeParameterData>().Build();
            RequireForUpdate(prefabQuery);
        }

        protected override void OnUpdate()
        {
            var entities = prefabQuery.ToEntityArray(Allocator.Temp);
            foreach (Entity entity in entities)
            {
                if (!prefabSystem.TryGetPrefab(entity, out PrefabBase prefabBase))
                {
                    continue;
                }

                if (prefabBase != null)
                {
                    if (
                        EntityManager.TryGetComponent(entity, out OutsideTradeParameterData data)
                        && prefabSystem.GetPrefabName(entity).Contains("OutsideTradeParameters")
                    )
                    {
                        VanillaDataStorage.VanillaData = new VanillaData
                        {
                            m_ElectricityImportPrice = data.m_ElectricityImportPrice,
                            m_ElectricityExportPrice = data.m_ElectricityExportPrice,
                            m_WaterImportPrice = data.m_WaterImportPrice,
                            m_WaterExportPrice = data.m_WaterExportPrice,
                            m_WaterExportPollutionTolerance = data.m_WaterExportPollutionTolerance,
                            m_SewageExportPrice = data.m_SewageExportPrice,
                            m_AirWeightMultiplier = data.m_AirWeightMultiplier,
                            m_RoadWeightMultiplier = data.m_RoadWeightMultiplier,
                            m_TrainWeightMultiplier = data.m_TrainWeightMultiplier,
                            m_ShipWeightMultiplier = data.m_ShipWeightMultiplier,
                            m_AirDistanceMultiplier = data.m_AirDistanceMultiplier,
                            m_RoadDistanceMultiplier = data.m_RoadDistanceMultiplier,
                            m_TrainDistanceMultiplier = data.m_TrainDistanceMultiplier,
                            m_ShipDistanceMultiplier = data.m_ShipDistanceMultiplier,
                            m_AmbulanceImportServiceFee = data.m_AmbulanceImportServiceFee,
                            m_HearseImportServiceFee = data.m_HearseImportServiceFee,
                            m_FireEngineImportServiceFee = data.m_FireEngineImportServiceFee,
                            m_GarbageImportServiceFee = data.m_GarbageImportServiceFee,
                            m_PoliceImportServiceFee = data.m_PoliceImportServiceFee,
                            m_OCServiceTradePopulationRange = data.m_OCServiceTradePopulationRange,
                        };
#if DEBUG
                        Mod.log.Info(
                            $"Vanilla data saved: {VanillaDataStorage.VanillaData.ToJSONString()}"
                        );
#endif
                    }
                }
            }
            Mod.m_Setting.VanillaDataFromStorage = VanillaDataStorage.VanillaData;
            //GameManager.instance.localizationManager.AddSource(
            //    "en-US",
            //    new LocaleEN(Mod.m_Setting)
            //);
            Enabled = false;
        }
    }
}
