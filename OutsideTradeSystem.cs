using Colossal.Entities;
using Colossal.Serialization.Entities;
using Game.City;
using Game.Prefabs;
using Game;
using System;
using Unity.Collections;
using Unity.Entities;

namespace TradingCostTweaker
{
    public partial class OutsideTradeSystem : GameSystemBase
    {
        private PrefabSystem prefabSystem;
        private EntityQuery prefabQuery;
        private Setting settings = Mod.m_Setting;
        private readonly VanillaData VanillaData = new();

        protected override void OnCreate()
        {
            base.OnCreate();

            prefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            prefabQuery = GetEntityQuery(new EntityQueryDesc()
            {
                All = [
                    ComponentType.ReadWrite<PrefabData>(),
                    ComponentType.ReadWrite<OutsideTradeParameterData>()
                    ],
            });
            RequireForUpdate(prefabQuery);

        }

        protected override void OnUpdate()
        {
            try
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
                        if (EntityManager.TryGetComponent(entity, out OutsideTradeParameterData data))
                        {
                            data.m_ElectricityImportPrice = (float)(settings.ElectricityImportPrice / 100d * VanillaData.ElectricityImportPrice);
                            data.m_ElectricityExportPrice = (float)(settings.ElectricityExportPrice / 100d * VanillaData.ElectricityExportPrice);
                            data.m_WaterImportPrice = (float)(settings.WaterImportPrice / 100d * VanillaData.WaterImportPrice);
                            data.m_WaterExportPrice = (float)(settings.WaterExportPrice / 100d * VanillaData.WaterExportPrice);
                            data.m_WaterExportPollutionTolerance = (float)(settings.WaterExportPollutionTolerance / 100d);
                            data.m_SewageExportPrice = (float)(settings.SewageExportPrice / 100d * VanillaData.SewageExportPrice);
                            data.m_OCServiceTradePopulationRange = settings.PopulationMultiplier;
                            data.m_GarbageImportServiceFee = (int)(settings.GarbageFee / 100d * VanillaData.GarbageFee);
                            data.m_AmbulanceImportServiceFee = (int)(settings.AmbulanceFee / 100d * VanillaData.AmbulanceFee);
                            data.m_HearseImportServiceFee = (int)(settings.HearseFee / 100d * VanillaData.HearseFee);
                            data.m_FireEngineImportServiceFee = (int)(settings.FireEngineFee / 100d * VanillaData.FireEngineFee);
                            data.m_PoliceImportServiceFee = (int)(settings.PoliceFee / 100d * VanillaData.PoliceFee);

                            data.m_RoadDistanceMultiplier = (int)(settings.RoadDistanceMultiplier / 100d * VanillaData.RoadDistanceMultiplier);
                            data.m_RoadWeightMultiplier = (int)(settings.RoadWeightMultiplier / 100d * VanillaData.RoadWeightMultiplier);
                            data.m_AirDistanceMultiplier = (int)(settings.AirDistanceMultiplier / 100d * VanillaData.AirDistanceMultiplier);
                            data.m_AirWeightMultiplier = (int)(settings.AirWeightMultiplier / 100d * VanillaData.AirWeightMultiplier);
                            data.m_ShipDistanceMultiplier = (int)(settings.ShipDistanceMultiplier / 100d * VanillaData.ShipDistanceMultiplier);
                            data.m_ShipWeightMultiplier = (int)(settings.ShipWeightMultiplier / 100d * VanillaData.ShipWeightMultiplier);
                            data.m_TrainDistanceMultiplier = (int)(settings.TrainDistanceMultiplier / 100d * VanillaData.TrainDistanceMultiplier);
                            data.m_TrainWeightMultiplier = (int)(settings.TrainWeightMultiplier / 100d * VanillaData.TrainWeightMultiplier);

                            EntityManager.SetComponentData(entity, data);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Mod.log.Error(e);
            }
        }
    }
}
