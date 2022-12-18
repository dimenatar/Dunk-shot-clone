using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryProjection : MonoBehaviour, IBallReceiver
{
    [SerializeField] private DragController _dragController;

    [SerializeField] private LayerMask _obstacles;
    [SerializeField] private Transform _ball;

    [SerializeField] private float _force = 0f;
    [SerializeField] private float _drag = 1;
    [SerializeField] private int _maxIterations = 10;
    [SerializeField] private float _segmentStepModulo = 10f;

    private Vector3? _startPosition;

    private Vector3[] segments;
    private int numSegments = 0;
    private int maxSegmentCount = 300;
    private bool _isSimulating;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        DragController.DragStarted += StartSimulating;
        DragController.DragEnded += StopSimulating;
        DragController.DragChanged += SetCurrentForce;
        BallSpawner.BallSpawned += SetBall;
        BallSkinConrtoller.SkinChanged += SetBall;
    }


    private void Update()
    {
        ManageDrag();
    }

    private void OnDestroy()
    {
        DragController.DragStarted -= StartSimulating;
        DragController.DragEnded -= StopSimulating;
        DragController.DragChanged -= SetCurrentForce;
        BallSpawner.BallSpawned -= SetBall;
        BallSkinConrtoller.SkinChanged -= SetBall;
    }

    public void SetStartPosition(Vector3 startPosition)
    {
        _startPosition = startPosition;
    }

    public void SetCurrentForce(float force)
    {
        _force = force;
    }

    public void SetBall(GameObject ball)
    {
        _ball = ball.transform;
    }

    private void StartSimulating()
    {
        _isSimulating = true;
    }

    private void ManageDrag()
    {
        _startPosition = _ball.transform.position;

        if (_isSimulating && _startPosition != null && _dragController.CurrentDrag >= _dragController.MinDrag)
        {
            SimulatePath(transform.gameObject, _ball.up * _force, _drag, _maxIterations);
        }
        else
        {
            lineRenderer.Clear();
        }
    }

    private void StopSimulating()
    {
        _isSimulating = false;
        _startPosition = null;
    }

    private void SimulatePath(GameObject obj, Vector3 forceDirection, float drag, float maxIterations)
    {
        float timestep = Time.fixedDeltaTime;

        float stepDrag = 1 - drag * timestep;
        Vector3 velocity = forceDirection * timestep;
        Vector3 gravity = Physics.gravity * timestep * timestep;

        if (segments == null || segments.Length != maxSegmentCount)
        {
            segments = new Vector3[maxSegmentCount];
        }

        segments[0] = _startPosition.Value;
        numSegments = 1;

        var nextPosition = _startPosition.Value;

        for (int i = 0; i < maxIterations && numSegments < maxSegmentCount; i++)
        {
            velocity += gravity;
            velocity *= stepDrag;

            var casted = Physics2D.RaycastAll(nextPosition, velocity - nextPosition, Vector3.Distance(nextPosition, velocity), _obstacles);

            if (casted.Length > 0)
            {
                Debug.DrawRay(nextPosition, velocity, Color.red, 1f);

                velocity = Vector3.Reflect(velocity + Vector3.up/3, casted[0].normal) * _ball.GetComponent<Rigidbody2D>().sharedMaterial.bounciness / 4;

                //SimulatePath(obj, Vector3.Reflect(nextPosition - velocity, casted[0].normal), drag, maxIterations - i);
            }

            nextPosition += velocity;

            if (i % _segmentStepModulo == 0)
            {


                segments[numSegments] = nextPosition;
                numSegments++;
            }
        }

        Draw();
    }

    private void Draw()
    {
        lineRenderer.transform.position = segments[0];

        lineRenderer.positionCount = numSegments;
        for (int i = 0; i < numSegments; i++)
        {
            lineRenderer.SetPosition(i, segments[i]);
        }
    }
}
