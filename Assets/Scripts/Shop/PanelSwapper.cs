using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwapper : MonoBehaviour
{
    [SerializeField] private GameObject _balls;
    [SerializeField] private GameObject _background;

    public void ShowBalls()
    {
        _background.SetActive(false);
        _balls.SetActive(true);
    }

    public void ShowBackgrounds()
    {
        _background.SetActive(true);
        _balls.SetActive(false);
    }
}
