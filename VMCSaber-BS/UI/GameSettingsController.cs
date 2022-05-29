using System;
using System.Reflection;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.ViewControllers;
using Zenject;

namespace VMCSaberBS.UI
{
    [ViewDefinition("VMCSaberBS.UI.Views.GameSettings.bsml")]
    [HotReload(RelativePathToLayout = @"..\Views\GameSettings.bsml")]
    public class GameSettingsController: BSMLAutomaticViewController, IInitializable, IDisposable
    {
        private PluginConfig _pluginConfig = null;

        public override string Content => BeatSaberMarkupLanguage.Utilities.GetResourceContent(Assembly.GetExecutingAssembly(), "VMCSaberBS.UI.Views.GameSettings.bsml");

        [Inject]
        public void Construct(PluginConfig pluginConfig)
        {
            _pluginConfig = pluginConfig;
        }
        
        public void Initialize()
        {
            GameplaySetup.instance.AddTab("VMC Saber", "VMCSaberBS.UI.Views.GameSettings.bsml", this);
        }
        
        public void Dispose()
        {
            if (GameplaySetup.IsSingletonAvailable && BSMLParser.IsSingletonAvailable)
            {
                GameplaySetup.instance.RemoveTab("VMC Saber");
            }
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
        
        [UIValue("enable_controller_pos")]
        public bool EnableControllerPos
        {
            get => _pluginConfig.EnableControllerPos;
            set
            {
                _pluginConfig.EnableControllerPos = value;
                NotifyPropertyChanged("enable_controller_pos");
            }
        }
    }
}