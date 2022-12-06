using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool _isHolding;
    public bool _isEditor;

    public bool IsHolding => _isHolding;

    public event Action OnMouseDown;
    public event Action OnMouseUp;

    private void Awake()
    {
#if UNITY_EDITOR
            _isEditor = true;
#else
        _isEditor = false;
#endif
    }

    void Update()
    {
        if (_isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isHolding = true;
                OnMouseDown?.Invoke();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isHolding = false;
                OnMouseUp?.Invoke();
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _isHolding = true;
                    OnMouseDown?.Invoke();
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    _isHolding = false;
                    OnMouseUp?.Invoke();
                }
            }
        }
    }

    public Vector3 GetMousePosition()
    {
        return _isEditor ? Input.mousePosition : (Input.touchCount > 0 ? (Vector3)Input.GetTouch(0).position : Vector3.zero);
    }
}
