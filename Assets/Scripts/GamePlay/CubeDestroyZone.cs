using UnityEngine;

public class CubeDestroyZone : MonoBehaviour
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public bool IsInDestroyZone(Vector3 cubePosition)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, cubePosition);
    }
}
