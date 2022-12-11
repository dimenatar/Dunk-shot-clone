using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HoopPrefab
{
    [SerializeField] private HoopTypes _hoopType;
    [SerializeField] private int _minLevelOrderToSpawn;
    [SerializeField, Range(0.0f, 1.0f)] private float _chanceToSpawn;
    [SerializeField] private GameObject _prefab;

    public HoopTypes HoopType => _hoopType;
    public int MinLevelOrderToSpawn => _minLevelOrderToSpawn;
    public float ChanceToSpawn => _chanceToSpawn;
    public GameObject Prefab => _prefab;
}
