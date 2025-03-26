using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private TowerManager towerManager;
    [SerializeField] private List<DropZone> dropZones;
    [SerializeField] private CubeDestroyZone destroyZone;
    [SerializeField] private DraggableCube cubePrefab;

    public override void InstallBindings()
    {
        Container.Bind<GameConfig>().FromInstance(gameConfig).AsSingle();
        Container.Bind<ITower>().To<TowerManager>().FromInstance(towerManager).AsSingle();
        Container.Bind<List<DropZone>>().FromInstance(dropZones).AsSingle();
        Container.Bind<GameModel>().AsSingle().NonLazy();
        Container.Bind<GameViewModel>().AsSingle();
        Container.Bind<CubeSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.BindInstance(destroyZone);

        Container.Bind<IDraggableCubeFactory>()
            .To<DraggableCubeFactory>()
            .AsSingle()
            .WithArguments(cubePrefab);

        var gameModel = Container.Resolve<GameModel>();
        gameModel.Initialize(gameConfig);
    }
}

