// Ignore Spelling: Preload

using System;
using Colossal.Entities;
using Colossal.Serialization.Entities;
using Game;
using Game.City;
using Game.Prefabs;
using Unity.Collections;
using Unity.Entities;

namespace TradingCostTweaker.Systems
{
    public partial class UIUpdate : GameSystemBase
    {
        private EntityQuery populationQuery;
        public double PopulationValue = 0;
        private readonly Setting settings = Mod.m_Setting;

        protected override void OnCreate()
        {
            base.OnCreate();

            populationQuery = SystemAPI.QueryBuilder().WithAll<Population>().Build();
            RequireForUpdate(populationQuery);
        }

        protected override void OnGamePreload(Purpose purpose, GameMode mode)
        {
            base.OnGamePreload(purpose, mode);

            if (mode == GameMode.Game)
            {
                settings.NotGameMode = false;
                Enabled = true;
                World
                    .DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<CostTweakingSystem>()
                    .Enabled = true;
            }
            else
            {
                settings.NotGameMode = true;
                Enabled = false;
                World
                    .DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<CostTweakingSystem>()
                    .Enabled = false;
            }
        }

        protected override void OnUpdate()
        {
            try
            {
                var entities = populationQuery.ToEntityArray(Allocator.Temp);
                foreach (Entity entity in entities)
                {
                    if (EntityManager.TryGetComponent(entity, out Population data))
                    {
                        settings.PopulationValue = data.m_Population;
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
