using Zenject;

public class DraggableCubeFactory : IFactory<DraggableCube>, IDraggableCubeFactory
{
    private readonly DiContainer _container;
    private readonly DraggableCube _prefab;

    public DraggableCubeFactory(DiContainer container, DraggableCube prefab)
    {
        _container = container;
        _prefab = prefab;
    }

    public DraggableCube Create()
    {
        return _container.InstantiatePrefabForComponent<DraggableCube>(_prefab);
    }
}