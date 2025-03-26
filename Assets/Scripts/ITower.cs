using UnityEngine;
using Transform = UnityEngine.Transform;

public interface ITower
{
    void AddCubeToTower(GameObject cube);
    bool CanPlaceCube(GameObject cube, out Transform lastCube);
    Transform GetTowerPanel();
    void DisappearCube(Transform cube);
    void RemoveCube(Transform cube);
}