using System;
using System.ComponentModel;
using System.Reflection;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.ViewControllers;
using UnityEngine;
using Zenject;

namespace VMCSaberBS.UI
{
    [ViewDefinition("VMCSaberBS.UI.Views.GameSettings.bsml")]
    [HotReload(RelativePathToLayout = @"..\Views\GameSettings.bsml")]
    public class GameSettingsController: BSMLAutomaticViewController, IInitializable
    {
        [Inject]
        private readonly PluginConfig _pluginConfig = null;

        public override string Content => BeatSaberMarkupLanguage.Utilities.GetResourceContent(Assembly.GetExecutingAssembly(), "VMCSaberBS.UI.Views.GameSettings.bsml");

        public void Initialize()
        {
            GameplaySetup.instance.AddTab("VMC Saber", "VMCSaberBS.UI.Views.GameSettings.bsml", this);
        }

        
        
        [UIValue("scale")]
        public float Scale
        {
            get => _pluginConfig.SaberScale;
            set
            {
                _pluginConfig.SaberScale = value;
                NotifyPropertyChanged("scale");
            }
        }

        [UIValue("enable_controller_rot")]
        public bool EnableControllerRot
        {
            get => _pluginConfig.EnableControllerRot;
            set
            {
                _pluginConfig.EnableControllerRot = value;
                NotifyPropertyChanged("enable_controller_rot");
            }
        }
    }
}