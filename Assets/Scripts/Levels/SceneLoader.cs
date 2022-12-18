using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }

    public void LoadSceneAsync(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    public void LoadAdditiveSceneAsyc(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public void SetActiveScene(string name)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
    }

    public void UnloadScene(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }

    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    public void Reload()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
