using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressLoader : MonoBehaviour
{
    [SerializeField] private ProgressManager _progressManager;

    [SerializeField] private int _levelAmount = 20;
    [SerializeField] private int _bonusLevelAmount = 5;

    [SerializeField] private int _minRandomLevel = 5;

    private const string LEVEL_NAME = "Level ";
    private const string BONUS_NAME = "Bonus ";
    private const string SCENE_NAME_KEY = "Scene";
    private const string LEVEL_NUMBER = "LevelNumber";

    private void Awake()
    {
        Application.targetFrameRate = 60;
        LoadScene();    
    }

    public void LoadScene()
    {
        if (_progressManager.IsCompletedAllLevels())
        {
            print("Loading random scene");
            LoadRandomLevel(SceneManager.GetActiveScene().name);
            return;
        }

        string sceneName = ProgressManager.GetCurrentSceneName();

        print(sceneName);
        if (sceneName != "Level 1")
        {
            SceneManager.LoadScene(sceneName);
        }
    }



    private void LoadRandomLevel(string current)
    {
        List<string> availableScenes = new List<string>();

        for (int i = _minRandomLevel; i <= _levelAmount; i++)
        {
            availableScenes.Add(LEVEL_NAME + i.ToString());
        }

        for (int i = 1; i <= _bonusLevelAmount; i++)
        {
            availableScenes.Add(BONUS_NAME + i.ToString());
        }

        if (availableScenes.Count > 2)
        {
            SceneManager.LoadScene(availableScenes.GetRandom(scene => scene != current));
        }
    }
}
