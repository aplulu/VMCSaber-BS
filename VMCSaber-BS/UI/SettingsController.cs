using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using BeatSaberMarkupLanguage.ViewControllers;
using VMCSaberBS.Managers;
using Zenject;

namespace VMCSaberBS.UI
{
    [ViewDefinition("VMCSaberBS.UI.Views.Settings.bsml")]
    [HotReload(RelativePathToLayout = @"..\Views\Settings.bsml")]
    public class SettingsController: BSMLAutomaticViewController, IInitializable
    {
        [Inject]
        private PluginConfig _pluginConfig = null;

        [Inject]
        private SaberEventEmitter _emitter = null;
        
        public void Initialize()
        {
            BSMLSettings.instance.AddSettingsMenu("VMC Saber", "VMCSaberBS.UI.Views.Settings.bsml", this);
        }
        
        [UIValue("send_port")]
        public string SendPort
        {
            get => _pluginConfig.SendPort.ToString();
            set
            {
                if (!int.TryParse(value, out var port)) return;
                _pluginConfig.SendPort = port;
                NotifyPropertyChanged("send_port");
                _emitter.Initialize();
            }
        }
    }
}