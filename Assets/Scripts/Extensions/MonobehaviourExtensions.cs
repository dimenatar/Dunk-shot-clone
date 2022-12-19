using System;
using System.Collections;
using UnityEngine;

public class MonobehaviourExtensions : MonoBehaviour
{
    public static MonobehaviourExtensions Instance { get; private set; }

    private void Awake()
    {
        SetupInstance();
    }

    public static void DODelayed(Action action, float delay, bool unscaledTime = false)
    {
        Instance.StartCoroutine(Instance.Delayed(action, delay, unscaledTime));
    }

    public static void StopCurrentTask() => Instance.StopAllCoroutines();

    private void SetupInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(this);
        }
    }

    private IEnumerator Delayed(Action task, float delay, bool unscaledTime)
    {
        float timer = 0f;

        while (timer < delay)
        {
            timer += unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;

            yield return null;
        }
        task?.Invoke();
    }
}
