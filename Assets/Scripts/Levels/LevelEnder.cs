using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder : MonoBehaviour
{
    [SerializeField] private HoopsController _controller;
    [SerializeField] private LevelRestarter _levelRestarter;

    [SerializeField] private EndPanel _endPanel;

    private bool _isShown;

    public static event Action LevelEnded;

    private void Awake()
    {
        DeathZone.BallEntered += CheckForLose;
    }

    private void OnDestroy()
    {
        DeathZone.BallEntered -= CheckForLose;
    }

    private void OnLevelFailed()
    {
        EndLevel();
        ShowPanel(false);
    }

    private void OnLevelWon()
    {
        EndLevel();
        ShowPanel(true);
    }

    private void EndLevel()
    {
        if (!_isShown)
        {
            _isShown = true;

            LevelEnded?.Invoke();

            Time.timeScale = 0f;

        }
    }

    private void ShowPanel(bool isWin)
    {
        _endPanel.ShowPanel(isWin);
    }

    private void CheckForLose()
    {
        if (_controller.Index == 0)
        {
            _levelRestarter.Restart();
        }
        else
        {
            OnLevelFailed();
            Time.timeScale = 0;
        }
    }
}
