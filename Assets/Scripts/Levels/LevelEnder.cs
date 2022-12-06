using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder : MonoBehaviour
{
    [SerializeField] private ObjectScaler _scaler;
    [SerializeField] private EndPanel _endPanel;

    private bool _isShown;

    public static event Action LevelEnded;

    private void Awake()
    {

    }

    private void OnDestroy()
    {

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

            _scaler.UnSclale(update: true);

            LevelEnded?.Invoke();

            Time.timeScale = 0f;

        }
    }

    private void ShowPanel(bool isWin)
    {
        _endPanel.ShowPanel(isWin);
    }
}
