using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimeScale : MonoBehaviour
{
    public void Set(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
