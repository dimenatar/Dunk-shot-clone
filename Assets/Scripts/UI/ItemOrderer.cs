using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOrderer : MonoBehaviour
{
    [SerializeField] private List<Transform> _items;

    private void Start()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].SetSiblingIndex(i);
        }
    }
}
