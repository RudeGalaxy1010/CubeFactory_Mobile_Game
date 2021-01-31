using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class YSwipeRegistrar : MonoBehaviour, ISwipeRegastrar, IDragHandler, IBeginDragHandler
{
    [SerializeField] private float minDeltaToRegister = 3f;

    public UnityAction OnSwipeRegistered { get; set; }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var delta = eventData.delta.y;
        if (Mathf.Abs(delta) > minDeltaToRegister)
        {
            OnSwipeRegistered?.Invoke();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // This thing is necessary to be here (Bruh)
        // It won't work without this
    }
}
