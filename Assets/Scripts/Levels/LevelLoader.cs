using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private ProgressManager _progressManager;
    [SerializeField] private SceneLoader _loader;

    [SerializeField] private int _currentLevelNumber;

    public static event Action OnReload;

    public void Reload()
    {
        OnReload?.Invoke();
        _loader.Reload();
    }

    public void ManualRestart()
    {
        _loader.Reload();
    }
}
