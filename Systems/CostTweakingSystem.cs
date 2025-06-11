using System;
using Colossal.Entities;
using Colossal.Json;
using Game;
using Game.Prefabs;
using Unity.Collections;
using Unity.Entities;

namespace TradingCostTweaker.Systems
{
    public partial class CostTweakingSystem : GameSystemBase
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
            Setting settings = Mod.m_Setting;
            if (settings.Changes)
            {
                VanillaData vanillaData = VanillaDataStorage.VanillaData;
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
                            if (
                                EntityManager.TryGetComponent(
                                    entity,
                                    out OutsideTradeParameterData data
                                )
                                && prefabSystem
                                    .GetPrefabName(entity)
                                    .Contains("OutsideTradeParameters")
                            )
                            {
                                try
                                {
                                    data.m_ElectricityImportPrice = (float)(
                                        settings.ElectricityImportPrice
                                        / 100d
                                        * vanillaData.m_ElectricityImportPrice
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_ElectricityExportPrice = (float)(
                                        settings.ElectricityExportPrice
                                        / 100d
                                        * vanillaData.m_ElectricityExportPrice
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_WaterImportPrice = (float)(
                                        settings.WaterImportPrice
                                        / 100d
                                        * vanillaData.m_WaterImportPrice
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_WaterExportPrice = (float)(
                                        settings.WaterExportPrice
                                        / 100d
                                        * vanillaData.m_WaterExportPrice
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_WaterExportPollutionTolerance = (float)(
                                        settings.WaterExportPollutionTolerance
                                        / 100d
                                        * vanillaData.m_WaterExportPollutionTolerance
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_SewageExportPrice = (float)(
                                        settings.SewageExportPrice
                                        / 100d
                                        * vanillaData.m_SewageExportPrice
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_AirWeightMultiplier = (float)(
                                        settings.AirWeightMultiplier
                                        / 100d
                                        * vanillaData.m_AirWeightMultiplier
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_RoadWeightMultiplier = (float)(
                                        settings.RoadWeightMultiplier
                                        / 100d
                                        * vanillaData.m_RoadWeightMultiplier
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_TrainWeightMultiplier = (float)(
                                        settings.TrainWeightMultiplier
                                        / 100d
                                        * vanillaData.m_TrainWeightMultiplier
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_ShipWeightMultiplier = (float)(
                                        settings.ShipWeightMultiplier
                                        / 100d
                                        * vanillaData.m_ShipWeightMultiplier
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_AirDistanceMultiplier = (float)(
                                        settings.AirDistanceMultiplier
                                        / 100d
                                        * vanillaData.m_AirDistanceMultiplier
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_RoadDistanceMultiplier = (float)(
                                        settings.RoadDistanceMultiplier
                                        / 100d
                                        * vanillaData.m_RoadDistanceMultiplier
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_TrainDistanceMultiplier = (float)(
                                        settings.TrainDistanceMultiplier
                                        / 100d
                                        * vanillaData.m_TrainDistanceMultiplier
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_ShipDistanceMultiplier = (float)(
                                        settings.ShipDistanceMultiplier
                                        / 100d
                                        * vanillaData.m_ShipDistanceMultiplier
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_AmbulanceImportServiceFee = (float)(
                                        settings.AmbulanceFee
                                        / 100d
                                        * vanillaData.m_AmbulanceImportServiceFee
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_HearseImportServiceFee = (float)(
                                        settings.HearseFee
                                        / 100d
                                        * vanillaData.m_HearseImportServiceFee
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_FireEngineImportServiceFee = (float)(
                                        settings.FireEngineFee
                                        / 100d
                                        * vanillaData.m_FireEngineImportServiceFee
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_GarbageImportServiceFee = (float)(
                                        settings.GarbageFee
                                        / 100d
                                        * vanillaData.m_GarbageImportServiceFee
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_PoliceImportServiceFee = (float)(
                                        settings.PoliceFee
                                        / 100d
                                        * vanillaData.m_PoliceImportServiceFee
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }
                                try
                                {
                                    data.m_OCServiceTradePopulationRange = (int)(
                                        settings.PopulationMultiplier
                                        / 100d
                                        * vanillaData.m_OCServiceTradePopulationRange
                                    );
                                }
                                catch (Exception ex)
                                {
                                    Mod.log.Error(ex);
                                }

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
}
