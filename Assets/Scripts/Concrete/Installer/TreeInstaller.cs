using UnityEngine;
using Zenject;

namespace EmreErkanGames
{
    public class TreeInstaller : MonoInstaller<TreeInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IHealtController>()
                .To<HealtController>()
                .AsSingle();

            Container
                .BindInstance(1f)
                .WithId("StartingHealt");

            Container
                .Bind<INameplate>()
                .To<Nameplate>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<IKillable>().
                To<Tree>().
                FromComponentOnRoot().
                AsSingle();

            Container
                .Bind<Renderer>()
                .FromComponentOnRoot()
                .AsSingle();
        }
    }
}