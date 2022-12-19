using System;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    [SerializeField] private HoopTrigger _hoopTrigger;

    public event Action<Hoop> BallEntered;

    private void Awake()
    {
        _hoopTrigger.BallEntered += AddBall;
    }

    private void OnDestroy()
    {
        _hoopTrigger.BallEntered -= AddBall;
    }

    private void AddBall(BallForce ballForce)
    {
        if (ballForce.transform.parent != transform)
        {
            ballForce.SetStatic(true);

            ballForce.transform.SetParent(transform);
            ballForce.transform.rotation = Quaternion.identity;

            BallEntered?.Invoke(this);
        }
    }
}
