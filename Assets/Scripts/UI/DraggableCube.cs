using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class DraggableCube : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Inject] private ITower _tower;
    [Inject] private List<DropZone> _dropZones;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Vector3 _originalPosition;
    private Image _image;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _image = GetComponent<Image>();
    }

    public void SetColor(Color color)
    {
        if (_image != null)
        {
            _image.color = color;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _originalPosition = _rectTransform.position;
        _canvasGroup.alpha = 0.6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResetDragState();
        foreach (var zone in _dropZones)
        {
            if (zone.IsInside(_rectTransform))
            {
                zone.HandleDrop(transform, _tower);
                return;
            }
        }

        ReturnToOrigin();
    }
    private void ResetDragState()
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }
    public void ReturnToOrigin()
    {
        _rectTransform.position = _originalPosition;
    }
}