using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] protected ShopItemNames _name;
    [SerializeField] protected Image _preview;
    [SerializeField] protected Button _button;
    [SerializeField] protected TextMeshProUGUI _price;
    [SerializeField] protected GameObject _pricePanel;

    protected ShopItemState _state = ShopItemState.Available;
    protected bool _isActive;

    public ShopItemState ItemState => _state;
    public ShopItemNames Name => _name;
    public bool IsActive => _isActive;

    public event Action Clicked;

    protected virtual void Awake()
    {
        _button.onClick.AddListener(() => Clicked?.Invoke());
    }

    public virtual void SetPrice(int price)
    {
        _price.text = price.ToString();
    }

    public virtual void SetBought()
    {
        print("BOUGHT");
        _state = ShopItemState.Bought;
        _pricePanel.SetActive(false);
    }

    public virtual void SetIdle()
    {
        _state = ShopItemState.Bought;
        _isActive = false;
    }

    public virtual void SetActive()
    {
        _state = ShopItemState.Set;
        _isActive = true;
        _pricePanel.SetActive(false);
    }

    public void SetPreview(Sprite sprite)
    {
        _preview.sprite = sprite;
    }
}
