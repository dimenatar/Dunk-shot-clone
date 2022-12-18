using UnityEngine;

public class BackgroundItem : ShopItem
{
    [SerializeField] private RectTransform _mask;
    [SerializeField] private Vector2 _activeSize;

    private Vector2 _baseSize;

    protected override void Awake()
    {
        _baseSize = _mask.sizeDelta;

        base.Awake();
    }

    public override void SetActive()
    {
        _mask.sizeDelta = _activeSize;

        base.SetActive();
    }

    public override void SetIdle()
    {
        _mask.sizeDelta = _baseSize;

        base.SetIdle();
    }
}
