using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _ball;

    [SerializeField] private InputManager _inputManager;

    [SerializeField] private float _dragCoefficient = 1f;
    [SerializeField] private float _minDrag = 1f;
    [SerializeField] private float _maxDrag = 50f;

    private Vector2 _startTouchPosition;

    private const int _baseScreenHeight = 1920;
    private const int _baseScreenWidth = 1080;

    private float _currentDrag;
    private bool _isDragging;

    public float CurrentDrag => _currentDrag;
    public float MinDrag => _minDrag;
    public float MaxDrag => _maxDrag;

    public static event Action DragStarted;
    public static event Action<float> DragChanged;
    public static event Action DragEnded; 

    private void Awake()
    {
        _inputManager.OnMouseDown += StartDrag;
        _inputManager.OnMouseUp += EndDrag;
    }

    private void Update()
    {
        if (_isDragging)
        {
            _currentDrag = GetForceByCurrentPosition();

            if (_currentDrag > _maxDrag) _currentDrag = _maxDrag;

            DragChanged?.Invoke(_currentDrag);
        }
    }

    private void StartDrag()
    {
        if (_ball.velocity == Vector2.zero)
        {
            _isDragging = true;
            _startTouchPosition = _inputManager.GetMousePosition();
            DragStarted?.Invoke();
        }
    }

    private void EndDrag()
    {
        _isDragging = false;
        DragEnded?.Invoke();
    }

    private float GetForceByCurrentPosition()
    {
        int width = Screen.width;
        int height = Screen.height;

        var mousePosition = _inputManager.GetMousePosition();

        var mousePositionInBaseCoordinates = new Vector2(mousePosition.x / width * _baseScreenWidth, mousePosition.y / height * _baseScreenHeight);

        return Vector2.Distance(_startTouchPosition, mousePositionInBaseCoordinates) * _dragCoefficient;
    }
}
