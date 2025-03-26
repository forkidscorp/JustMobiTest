using UnityEngine;

public abstract class DropZone : MonoBehaviour
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public bool IsInside(RectTransform cube)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, cube.position);
    }

    public abstract void HandleDrop(Transform cube, ITower tower);
}