using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowerManager : MonoBehaviour, ITower
{
    [Inject] private CubeSpawner _cubeSpawner;

    [SerializeField] private Transform _towerTransform;
    [SerializeField] private float _maxTowerHeight = 10f;
    [SerializeField] private float _horizontalOffset = 0.5f;
    private List<Transform> _towerCubes = new List<Transform>();

    public bool CanAddCube(float height)
    {
        float currentHeight = _towerCubes.Count > 0 ? _towerCubes[_towerCubes.Count - 1].position.y : _towerTransform.position.y;
        return (currentHeight + height <= _maxTowerHeight);
    }

    public void AddCube(Transform cube)
    {
        float cubeHeight = cube.GetComponent<RectTransform>().rect.height;
        Transform lastCube = _towerCubes.Count > 0 ? _towerCubes[_towerCubes.Count - 1] : null;
        float targetY = lastCube == null ? _towerTransform.position.y : lastCube.position.y + cubeHeight;

        cube.DOMoveY(targetY, 0.5f)
            .SetEase(Ease.OutBounce);

        _towerCubes.Add(cube);
    }

    public void RemoveCube(Transform cube)
    {
        if (_towerCubes.Contains(cube))
        {
            int index = _towerCubes.IndexOf(cube);
            _towerCubes.RemoveAt(index);

            cube.DOScale(Vector3.zero, 0.3f).OnComplete(() => Destroy(cube.gameObject));

            if (_towerCubes.Count > 0) 
            { 
                Transform lastCube = index > 0 ? _towerCubes[index - 1] : _towerCubes[index];
                float cubeHeight = cube.GetComponent<RectTransform>().rect.height;
                float targetY = lastCube == null ? _towerTransform.position.y : lastCube.position.y + cubeHeight;
                for (int i = index; i < _towerCubes.Count; i++)
                {
                    _towerCubes[i].DOMoveY(targetY, 0.5f)
                    .SetEase(Ease.OutBounce);
                    targetY += cubeHeight;
                }
            }  
        }
        else
        {
            DisappearCube(cube);
        }
    }
    public void DisappearCube(Transform cube)
    {
        if (!_towerCubes.Contains(cube)) {
            cube.DOScale(Vector3.zero, 0.3f).OnKill(() => Destroy(cube.gameObject));
            //_cubeSpawner.RespawnCube();
        }
        else{
            cube.GetComponent<DraggableCube>().ReturnToOrigin();
        }
    }

    public void AddCubeToTower(GameObject cube)
    {
        AddCube(cube.transform);
    }

    public bool CanPlaceCube(GameObject cube, out Transform lastCube)
    {
        lastCube = _towerCubes.Count > 0 ? _towerCubes[_towerCubes.Count - 1] : null;

        if (lastCube == null)
        {
            return true;
        }

        float cubeHeight = cube.GetComponent<RectTransform>().rect.height;
        float lastCubeTopY = lastCube.position.y + cubeHeight;

        float allowedXMin = lastCube.position.x - _horizontalOffset;
        float allowedXMax = lastCube.position.x + _horizontalOffset;

        return cube.transform.position.y >= lastCubeTopY &&
               cube.transform.position.x >= allowedXMin &&
               cube.transform.position.x <= allowedXMax;
    }
    public Transform GetTowerPanel()
    {
        return _towerTransform;
    }
}
