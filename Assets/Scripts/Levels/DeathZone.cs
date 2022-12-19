using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public static event Action BallEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BallForce ballForce))
        {
            BallEntered?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
