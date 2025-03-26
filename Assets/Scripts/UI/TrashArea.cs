using UnityEngine;
using Zenject;

public class TrashArea : DropZone
{
    [Inject] private CubeDestroyZone _destroyZone;
    public override void HandleDrop(Transform cube, ITower tower)
    {
        if (_destroyZone.IsInDestroyZone(cube.transform.position))
        {
            tower.RemoveCube(cube);
        }
        else {
            cube.GetComponent<DraggableCube>().ReturnToOrigin();
        }
    }
}