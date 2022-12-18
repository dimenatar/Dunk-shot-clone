using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    private void Awake()
    {
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void SetStatic(bool isStatic)
    {
        _rb.bodyType = isStatic ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
    }

    public void AddForce(float force)
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }
}
