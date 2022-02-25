using UnityEngine;
using Zenject;

namespace EmreErkanGames
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private GameObject _treePrefab;
        [SerializeField] private Camera _cameraInstance;
        [SerializeField] private TreeSpawnerType _treeSpawnerType;

        public override void InstallBindings()
        {
            Container
                .BindMemoryPoolCustomInterface<Tree, Tree.Pool, ITreePool>()
                .WithInitialSize(300)
                .FromComponentInNewPrefab(_treePrefab)
                .UnderTransformGroup("Trees");

            Container
                .Bind<ITreeController>()
                .To<TreeController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<Camera>()
                .FromInstance(_cameraInstance);

            Container
                .Bind<IMathUtility>()
                .To<MathUtility>()
                .AsSingle();

            Container
                .BindInstance(_treeSpawnerType)
                .AsSingle();
        }
    }
}