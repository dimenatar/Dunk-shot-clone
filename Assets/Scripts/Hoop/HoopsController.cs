using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopsController : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private HoopSpawner _hoopSpawner;

    [SerializeField] private List<Hoop> _hoops;

    private Hoop _currentHoop;
    private int _index;

    public static event Action BallAdded;

    private void Awake()
    {
        _currentHoop = _hoops[0];

        _hoops.ForEach(hoop => hoop.BallEntered += UpdateCurrentHoop);
    }

    private void Update()
    {
        if (_inputManager.IsHolding && Time.timeScale > 0)
        {
            RotateCurrentHoop();
        }
    }

    private void OnDestroy()
    {
        _hoops.ForEach(hoop => hoop.BallEntered -= UpdateCurrentHoop);
    }

    private void UpdateCurrentHoop(Hoop hoop)
    {
        if (_currentHoop == hoop) return;

        BallAdded?.Invoke();

        _currentHoop.transform.ScaleOutWithDiactivation();

        _currentHoop = hoop;
        _index++;
        
        // if current hoop is last of spawned
        if (_hoops.IndexOf(hoop) == _hoops.Count - 1 || _hoops.IndexOf(hoop) == -1)
        {
            _hoopSpawner.Spawn(_index, _currentHoop.transform.position.y, _currentHoop.transform.position.x, UpdateCurrentHoop);
        }
    }

    private void RotateCurrentHoop()
    {
        float AngleRad = Mathf.Atan2(_inputManager.GetWorldPosition().y - _currentHoop.transform.position.y, _inputManager.GetWorldPosition().x - _currentHoop.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        _currentHoop.transform.rotation = Quaternion.Euler(0, 0, AngleDeg + 90);
    }
}
