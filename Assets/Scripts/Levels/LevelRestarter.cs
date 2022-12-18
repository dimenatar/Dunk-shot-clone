using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestarter : MonoBehaviour
{
    [SerializeField] private BallSpawner _spawner;

    public void Restart()
    {
        _spawner.Spawn();
    }
}
