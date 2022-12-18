using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private StarController _starController;
    [SerializeField] private ShopItemsBundle _itemsSettings;

    [SerializeField] private List<ShopItem> _items;

    [SerializeField] private string _boughtItemsTag;
    [SerializeField] private string _currentItemTag;

    private ShopItem _current;

    public event Action<ShopItem> ActiveItemChanged;

    private void Start()
    {
        
        ManageBoughtItems();
        ManageCurrentItem();
        SetupItems();
        
    }

    protected virtual void ManageBoughtItems()
    {
        var boughtItemsKeys = ProgressManager.GetValue(_boughtItemsTag, new List<string>()) as Newtonsoft.Json.Linq.JArray;

        var list = boughtItemsKeys.ToObject<List<string>>();

        if (list.Count == 0)
        {
            list.Add(_itemsSettings.Items.First().Name.ToString());
            ProgressManager.SaveValue(_boughtItemsTag, list);
        }

        foreach (var item in boughtItemsKeys)
        {
            print($"{item} {item.GetType()}");
        }

        _items.Where(item => list.Contains(item.Name.ToString())).ToList().ForEach(item => item.SetBought());
    }

    protected virtual void ManageCurrentItem()
    {
        var currentItemName = (string)ProgressManager.GetValue(_currentItemTag, _itemsSettings.Items.First().Name.ToString());
        _current = _items.Find(item => item.Name.ToString() == currentItemName);

        print(_current.Name);
        _current.SetActive();
        
    }

    protected virtual void SetupItems()
    {
        _items.ForEach(item => item.Clicked += () => OnItemClick(item));

        _items.ForEach(item => item.SetPreview(_itemsSettings.Items.Find(setting => setting.Name == item.Name).Preview));
    }

    private void OnItemClick(ShopItem shopItem)
    {
        if (_current != shopItem)
        {
            if (shopItem.ItemState == ShopItemState.Bought)
            {
                SetCurrent(shopItem);
            }
            else if (_starController.SpendStars(_itemsSettings.Items.Find(item => item.Name == shopItem.Name).Price))
            {
                SaveBoughtItem(shopItem);
                SetCurrent(shopItem);
            }
        }
    }

    private void SetCurrent(ShopItem shopItem)
    {
        _current.SetIdle();
        _current = shopItem;

        _current.SetActive();
        ProgressManager.SaveValue(_currentItemTag, _current.Name.ToString());
        ActiveItemChanged?.Invoke(shopItem);
    }

    private void SaveBoughtItem(ShopItem shopItem)
    {
        var boughtItemsKeys = ProgressManager.GetValue(_boughtItemsTag, new List<string>()) as Newtonsoft.Json.Linq.JArray;

        var list = boughtItemsKeys.ToObject<List<string>>();

        list.Add(shopItem.Name.ToString());

        ProgressManager.SaveValue(_boughtItemsTag, list);
    }
}
