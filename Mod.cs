﻿using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;

namespace TradingCostTweaker
{
    public class Mod : IMod
    {
        public static string Name = "Trading Cost Tweaker";
        public static string Version = "1.0";
        public static string Author = "StarQ";

        public static ILog log = LogManager.GetLogger($"{nameof(TradingCostTweaker)}").SetShowsErrorsInUI(false);
        public static Setting m_Setting;

        public void OnLoad(UpdateSystem updateSystem)
        {
            //log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                //log.Info($"Current mod asset at {asset.path}");

            m_Setting = new Setting(this);
            m_Setting.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(m_Setting));

            AssetDatabase.global.LoadSettings(nameof(TradingCostTweaker), m_Setting, new Setting(this));

            updateSystem.UpdateAfter<OutsideTradeSystem>(SystemUpdatePhase.GameSimulation);
        }

        public void OnDispose()
        {
            //log.Info(nameof(OnDispose));
            if (m_Setting != null)
            {
                m_Setting.UnregisterInOptionsUI();
                m_Setting = null;
            }
        }
    }
}