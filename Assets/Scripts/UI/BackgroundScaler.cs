using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    [SerializeField] private Transform _background;

    private const float _zScale = 0.01f;
    private const float _baseWidth = 1080f;
    private const float _baseHeight = 1920f;

    private const float _ratio = _baseWidth / _baseHeight;

    private void Start()
    {
        SetScale(_background);
    }

    private void SetScale(Transform background) 
    {
        float width = Screen.width;
        float height = Screen.height;

        float ratio = width / height;

        background.localScale = new Vector3(background.localScale.x * (ratio / _ratio), background.localScale.y, _zScale);
    }
}
