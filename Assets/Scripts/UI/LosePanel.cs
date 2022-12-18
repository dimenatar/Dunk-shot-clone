using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private HoopsController _controller;
    [SerializeField] private LevelRestarter _levelRestarter;

    [SerializeField] private Transform _panel;

    private void Awake()
    {
        DeathZone.BallEntered += CheckForLose;
    }

    private void OnDestroy()
    {
        DeathZone.BallEntered -= CheckForLose;
    }

    private void CheckForLose()
    {
        if (_controller.Index == 0)
        {
            _levelRestarter.Restart();
        }
        else
        {
            _panel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
