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
        private EntityQuery populationQuery;
        //public int populationValue = 0;
        //public bool IsGameMode = false;
        private readonly Setting settings = Mod.m_Setting;
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
            populationQuery = GetEntityQuery(new EntityQueryDesc()
            {
                All = [
                    ComponentType.ReadOnly<Population>()
                    ]
            });
            RequireForUpdate(prefabQuery);
            RequireForUpdate(populationQuery);

        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            //IsGameMode = GameModeExtensions.IsGame(mode);
            //Mod.log.Info(mode);
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

                            EntityManager.SetComponentData(entity, data);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Mod.log.Error(e);
            }

            try
            {
                var entities = populationQuery.ToEntityArray(Allocator.Temp);
                foreach (Entity entity in entities)
                {
                    if (EntityManager.TryGetComponent(entity, out Population data))
                    {
                        //populationValue = data.m_Population;
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
