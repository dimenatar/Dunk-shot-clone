using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBall : MonoBehaviour, IBallReceiver
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _ball;

    [SerializeField] private float _yOffset = 1f;

    private void Awake()
    {
        BallSpawner.BallSpawned += SetBall;
        BallSkinConrtoller.SkinChanged += SetBall;
    }

    private void LateUpdate()
    {
        if (Time.timeScale > 0)
        FollowBall();
    }

    private void OnDestroy()
    {
        BallSpawner.BallSpawned -= SetBall;
        BallSkinConrtoller.SkinChanged -= SetBall;
    }

    public void SetBall(GameObject ball)
    {
        _ball = ball.transform;
    }

    private void FollowBall()
    {
        if (_ball.position.y + _yOffset > _camera.position.y)
        {
            _camera.position = new Vector3(_camera.position.x, _ball.position.y + _yOffset, _camera.position.z);
        }
    }
}
