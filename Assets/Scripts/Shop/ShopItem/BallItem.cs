using DG.Tweening;
using UnityEngine;

public class BallItem : ShopItem
{
    [SerializeField] private Transform _innerCircle;
    [SerializeField] private float _animatedScale = 0.8f;
    [SerializeField] private float _animationDuration = 0.5f;

    private Tween _pulsingTween;

    public override void SetActive()
    {
        _pulsingTween = _innerCircle.DOScale(_animatedScale, _animationDuration).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);

        base.SetActive();
    }

    public override void SetIdle()
    {
        _pulsingTween?.Kill(true);
        _innerCircle.localScale = Vector3.one;
        base.SetIdle();
    }
}
