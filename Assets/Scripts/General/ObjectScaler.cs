using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField] protected List<Transform> _objectsToScale;

    public void ScaleIn(float duration = 0.5f)
    {
        _objectsToScale.ForEach(obj => obj.ScaleIn(Ease.OutBack, duration: duration));
    }

    public void UnSclale(float duration = 0.5f, bool update = false)
    {
        print(_objectsToScale[0]);
        _objectsToScale.ForEach(obj => obj.ScaleOutWithDiactivation(duration, update));
    }
}
