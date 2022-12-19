using System;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    public static event Action Collision;

    private void Awake()
    {
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collision?.Invoke();
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
