using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 41)]
public class HoopsSettings : ScriptableObject
{
    [SerializeField] private List<HoopPrefab> _hoops;

    public List<HoopPrefab> Hoops => new List<HoopPrefab>(_hoops);
}
