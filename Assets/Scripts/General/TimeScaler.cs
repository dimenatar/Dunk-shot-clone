using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;

    [SerializeField] private float _scaledTime = 0.2f;
    [SerializeField] private float _duration = 1f;

    private Tween _tween;

    private bool _isMoving;
    private bool _isAllowedToScale = true;

    private void Awake()
    {
        LevelEnder.LevelEnded += PreventScaling;
    }

    private void OnDestroy()
    {
        LevelEnder.LevelEnded -= PreventScaling;
    }

    public void Scale(Action callback = null)
    {
        if (_isMoving)
        {
            ForceStopMoving();
        }

        if (_isAllowedToScale)
        {
            _isMoving = true;
            _tween = DOTween.To(() => Time.timeScale, x => Time.timeScale = x, _scaledTime, _duration).SetUpdate(true).SetEase(_curve).OnComplete(() => callback?.Invoke());
        }
    }

    public void ScaleBack(Action callback = null)
    {
        if (_isAllowedToScale)
        {
            _isMoving = true;
            _tween = DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, _duration).SetUpdate(true).SetEase(_curve).OnComplete(() => callback?.Invoke());
        }
    }

    public void ForceStopMoving()
    {
        if (_isMoving)
        {
            _tween.Kill();
        }
    }

    private void PreventScaling()
    {
        _isAllowedToScale = false;
        ForceStopMoving();
    }
}
