using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvisibleBackgroundPointerDown : MonoBehaviour, IPointerDownHandler
{
    public event Action OnMouseDown;

    public static event Action OnLevelStart;

    public void OnPointerDown(PointerEventData eventData)
    {
        Input.ResetInputAxes();

        OnMouseDown?.Invoke();
        OnLevelStart?.Invoke();

        Destroy(gameObject);
    }
}
