using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryProjection : MonoBehaviour
{
    [SerializeField] private DragController _dragController;

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
    }


    private void Update()
    {
        ManageDrag();
    }

    private void ManageDrag()
    {
        _startPosition = _ball.transform.position;

        if (_isSimulating && _startPosition != null && _dragController.CurrentDrag >= _dragController.MinDrag)
        {
            SimulatePath(transform.gameObject, _ball.up * _force, _drag);
        }
        else
        {
            lineRenderer.Clear();
        }
    }

    private void OnDestroy()
    {
        DragController.DragStarted -= StartSimulating;
        DragController.DragEnded -= StopSimulating;
        DragController.DragChanged -= SetCurrentForce;
    }

    public void SetStartPosition(Vector3 startPosition)
    {
        _startPosition = startPosition;
    }

    public void SetCurrentForce(float force)
    {
        _force = force;
    }

    private void StartSimulating()
    {
        _isSimulating = true;
    }

    private void StopSimulating()
    {
        _isSimulating = false;
        _startPosition = null;
    }

    private void SimulatePath(GameObject obj, Vector3 forceDirection, float drag)
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

        for (int i = 0; i < _maxIterations && numSegments < maxSegmentCount; i++)
        {
            velocity += gravity;
            velocity *= stepDrag;

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
