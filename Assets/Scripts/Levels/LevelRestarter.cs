using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestarter : MonoBehaviour
{
    [SerializeField] private BallSpawner _spawner;
    [SerializeField] private Transform _firstHoop;

    public void Restart()
    {
        _firstHoop.transform.rotation = Quaternion.identity;
        _spawner.Spawn();
    }
}
