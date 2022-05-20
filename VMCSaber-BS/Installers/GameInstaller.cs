using VMCSaberBS.Managers;
using Zenject;

namespace VMCSaberBS.Installers
{
    public class GameInstaller: Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameEventObserver>().AsSingle();
        }
    }
}