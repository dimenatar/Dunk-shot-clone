using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSkinConrtoller : MonoBehaviour
{
    [SerializeField] private ShopItemsBundle _bundle;
    [SerializeField] private Shop _shop;

    private GameObject _spawnedBall;

    public static event Action<GameObject> SkinChanged;

    private void Awake()
    {
        BallSpawner.BallSpawned += SetSpawnedBall;
        _shop.ActiveItemChanged += ReplaceBall;
    }

    private void OnDestroy()
    {
        BallSpawner.BallSpawned -= SetSpawnedBall;
    }

    private void SetSpawnedBall(GameObject ball)
    {
        _spawnedBall = ball;
    }

    private void ReplaceBall(ShopItem shopItem)
    {
        var prefab = _bundle.Items.Find(item => item.Name == shopItem.Name).Prefab;
        var updatedBall = Instantiate(prefab, _spawnedBall.transform.position, _spawnedBall.transform.rotation);
        updatedBall.transform.SetParent(_spawnedBall.transform.parent);

        updatedBall.GetComponent<Rigidbody2D>().velocity = _spawnedBall.GetComponent<Rigidbody2D>().velocity;
        updatedBall.GetComponent<Rigidbody2D>().rotation = _spawnedBall.GetComponent<Rigidbody2D>().rotation;

        Destroy(_spawnedBall);

        _spawnedBall = updatedBall;
        SkinChanged?.Invoke(_spawnedBall);
    }
}
