using System.Collections.Generic;
using UnityEngine;

public class UIButtonsSwapperOnStart : MonoBehaviour
{
    [SerializeField] private List<Transform> _objectsToScaleIn;
    [SerializeField] private List<Transform> _objectsToScaleOut;

    private void Awake()
    {
        Subscribe();
    }

    public void Subscribe()
    {
        InvisibleBackgroundPointerDown.OnLevelStart += Transit;
        InvisibleBackgroundPointerDown.OnLevelStart += Unsubscribe;
    }

    public void Unsubscribe()
    {
        InvisibleBackgroundPointerDown.OnLevelStart -= Transit;
    }

    private void Transit()
    {
        _objectsToScaleIn.ForEach(obj => obj.ScaleIn(duration: 0f));
        _objectsToScaleOut.ForEach(obj => obj.ScaleOutWithDiactivation(duration: 0f));

        Unsubscribe();
    }
}
