using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersPositionsScaler : MonoBehaviour
{
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private void Awake()
    {
        SetPositions();
    }

    private void SetPositions()
    {
        _leftBorder.position = new Vector3(ResolutionPositionsScaler.GetNormilizedXPosition(_leftBorder.position.x), _leftBorder.position.y, 0f);
        _rightBorder.position = new Vector3(ResolutionPositionsScaler.GetNormilizedXPosition(_rightBorder.position.x), _rightBorder.position.y, 0f);
    }
}
