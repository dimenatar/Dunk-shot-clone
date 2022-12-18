using System;
using System.Linq;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private ShopItemsBundle _balls;

    [SerializeField] private Transform _spawnPosition;

    public static event Action<GameObject> BallSpawned;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        var copy = Instantiate(GetPrefab(), _spawnPosition.position, Quaternion.identity);
        copy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        BallSpawned?.Invoke(copy);
    }

    private GameObject GetPrefab()
    {
        var ballName = ProgressManager.GetValue(Tags.CURRENT_BALL_TAG, _balls.Items.First().Name.ToString()).ToString();

        return _balls.Items.Find(item => item.Name.ToString() == ballName).Prefab;
    }
}
