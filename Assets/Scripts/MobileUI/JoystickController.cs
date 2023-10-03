using UnityEngine;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform Handle;
    [SerializeField] private float MoveRadius;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Handle.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPoint))
        {
            Vector2 offset = localPoint;
            Handle.anchoredPosition = Vector2.ClampMagnitude(offset, MoveRadius);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Handle.anchoredPosition = Vector2.zero;
    }
}
