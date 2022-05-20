using VMCSaberBS.UI;
using Zenject;

namespace VMCSaberBS.Installers
{
    public class MenuInstaller: Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameSettingsController>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingsController>().FromNewComponentAsViewController().AsSingle();
        }
    }
}