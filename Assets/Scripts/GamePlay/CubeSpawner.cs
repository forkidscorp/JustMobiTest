using UnityEngine;
using Zenject;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnParent;

    [Inject] private GameModel _gameModel;

    [Inject] private IDraggableCubeFactory _cubeFactory;

    private void Start()
    {
        for (int i = 0; i < _gameModel.CubeCount.Value; i++)
        {
            SpawnCube(Vector3.zero, _gameModel.CubeColors[i % _gameModel.CubeColors.Count]);
        }
    }
    public void SpawnCube(Vector3 position, Color color)
    {
        DraggableCube cube = _cubeFactory.Create();
        cube.transform.SetParent(_spawnParent, false);
        cube.transform.position = position;
        color.a = 1f;
        cube.SetColor(color);
    }
    public void RespawnCube()
    {
        if (_spawnParent.childCount < _gameModel.CubeCount.Value)
        {
            SpawnCube(Vector3.zero, _gameModel.CubeColors[Random.Range(0, _gameModel.CubeColors.Count)]);
        }
    }
}
