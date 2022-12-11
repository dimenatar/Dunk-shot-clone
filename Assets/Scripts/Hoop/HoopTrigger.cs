using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopTrigger : MonoBehaviour
{
    public event Action<BallForce> BallEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BallForce ballForce))
        {
            BallEntered?.Invoke(ballForce);
        }
    }
}
