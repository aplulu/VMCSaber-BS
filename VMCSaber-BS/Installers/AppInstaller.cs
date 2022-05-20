using VMCSaberBS.Managers;
using Zenject;

namespace VMCSaberBS.Installers
{
    public class AppInstaller: Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SaberEventEmitter>().AsSingle();
        }
    }
}