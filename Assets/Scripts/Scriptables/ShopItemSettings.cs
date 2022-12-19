using UnityEngine;

[System.Serializable]
public class ShopItemSettings
{
    [SerializeField] private ShopItemNames _name;
    [SerializeField] private Sprite _preview;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _prefab;

    public ShopItemNames Name => _name;
    public Sprite Preview => _preview;
    public int Price => _price;
    public GameObject Prefab => _prefab;
}
