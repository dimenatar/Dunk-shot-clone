using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    [SerializeField] private DragController _dragController;

    [SerializeField] private Rigidbody2D _rb;

    private void Awake()
    {
        DragController.DragEnded += AddForce;
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnDestroy()
    {
        DragController.DragEnded -= AddForce;
    }

    public void SetStatic(bool isStatic)
    {
        _rb.bodyType = isStatic ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
    }

    private void AddForce()
    {
        if (_dragController.CurrentDrag >= _dragController.MinDrag)
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.AddForce(transform.up * _dragController.CurrentDrag, ForceMode2D.Impulse);
        }
    }
}
