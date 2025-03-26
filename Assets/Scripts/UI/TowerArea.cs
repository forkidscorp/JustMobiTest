using UnityEngine;

public class TowerArea : DropZone
{
    public override void HandleDrop(Transform cube, ITower tower)
    {
        if (tower.CanPlaceCube(cube.gameObject, out Transform lastCube))
        {
            Vector3 worldPosition = cube.transform.position;

            cube.SetParent(tower.GetTowerPanel(), worldPositionStays: false);
            cube.transform.position = worldPosition;

            tower.AddCubeToTower(cube.gameObject);
        }
        else
        {
            tower.DisappearCube(cube);
        }
    }
}