using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 42)]
public class ShopItemsBundle : ScriptableObject
{
    [SerializeField] private List<ShopItemSettings> _items;

    public List<ShopItemSettings> Items => new List<ShopItemSettings>(_items);
}
