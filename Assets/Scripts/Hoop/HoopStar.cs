using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopStar : MonoBehaviour
{
    public static event Action StarCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BallForce ballForce))
        {
            StarCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
