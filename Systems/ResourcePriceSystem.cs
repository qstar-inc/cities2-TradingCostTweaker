//using Colossal.Entities;
//using Game.Prefabs;
//using Game;
//using Unity.Collections;
//using Unity.Entities;
//using Colossal.Json;
//using System.Collections.Generic;

//namespace TradingCostTweaker.Systems
//{
//    public static class VanillaResourceDataStorage
//    {
//        public static Dictionary<string, ResourcePriceData> ResourcePriceDataDict { get; set; } = new ();
//    }

//    public struct ResourcePriceData
//    {
//        public float m_PriceX;
//        public float m_PriceY;
//    }
//    public partial class ResourcePriceSystem : GameSystemBase
//    {
//        private PrefabSystem prefabSystem;
//        private EntityQuery prefabQuery;

//        protected override void OnCreate()
//        {
//            base.OnCreate();

//            prefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
//            prefabQuery = GetEntityQuery(new EntityQueryDesc()
//            {
//                All = new[] { ComponentType.ReadWrite<ResourceData>() },
//            });
//            RequireForUpdate(prefabQuery);
//        }

//        protected override void OnUpdate()
//        {
//            var entities = prefabQuery.ToEntityArray(Allocator.Temp);
//            foreach (Entity entity in entities)
//            {
//                if (!prefabSystem.TryGetPrefab(entity, out PrefabBase prefabBase))
//                {
//                    continue;
//                }

//                if (prefabBase != null)
//                {
//                    if (EntityManager.TryGetComponent(entity, out ResourceData data))
//                    {
//                        //Mod.log.Info($"{prefabSystem.GetPrefabName(entity)}: {data.ToJSONString()}");
//                        string name = prefabSystem.GetPrefabName(entity);
//                        float xPrice = data.m_Price.x;
//                        float yPrice = data.m_Price.y;

//                        ResourcePriceData rpd = new()
//                        {
//                            m_PriceX = xPrice,
//                            m_PriceY = yPrice
//                        };

//                        VanillaResourceDataStorage.ResourcePriceDataDict.Add(name, rpd);
//                    }
//                }
//            }
//            Enabled = false;
//        }
//    }
//}