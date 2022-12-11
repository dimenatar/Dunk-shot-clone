using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBall : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _ball;

    [SerializeField] private float _yOffset = 1f;

    private void LateUpdate()
    {
        FollowBall();
    }

    private void FollowBall()
    {
        if (_ball.position.y + _yOffset > _camera.position.y)
        {
            _camera.position = new Vector3(_camera.position.x, _ball.position.y + _yOffset, _camera.position.z);
        }
    }
}
