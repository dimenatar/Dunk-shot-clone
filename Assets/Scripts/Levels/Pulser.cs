using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulser : MonoBehaviour
{
    [SerializeField] private float _startScale = 1f;
    [SerializeField] private float _endScale = 1.2f;
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private int _loops = -1;
    [SerializeField] private bool _update = false;

    private void Start()
    {
        transform.DOPulse(_startScale, _endScale, _duration / 2f, _duration / 2f, _loops, _update);
    }
}
