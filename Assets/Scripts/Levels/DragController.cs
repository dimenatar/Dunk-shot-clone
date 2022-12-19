using System;
using UnityEngine;

public class DragController : MonoBehaviour, IBallReceiver
{

    [SerializeField] private InputManager _inputManager;

    [SerializeField] private float _dragCoefficient = 1f;
    [SerializeField] private float _minDrag = 1f;
    [SerializeField] private float _maxDrag = 50f;

    private Rigidbody2D _ball;
    private BallForce _ballForce;
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
        BallSpawner.BallSpawned += SetBall;
        BallSkinConrtoller.SkinChanged += SetBall;
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

    private void OnDestroy()
    {
        _inputManager.OnMouseDown -= StartDrag;
        _inputManager.OnMouseUp -= EndDrag;
        BallSpawner.BallSpawned -= SetBall;
        BallSkinConrtoller.SkinChanged -= SetBall;
    }

    public void SetBall(GameObject ball)
    {
        _ball = ball.GetComponent<Rigidbody2D>();
        _ballForce = ball.GetComponent<BallForce>();
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

        if (CurrentDrag >= MinDrag)
        {
            _ballForce.AddForce(CurrentDrag);
        }
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
