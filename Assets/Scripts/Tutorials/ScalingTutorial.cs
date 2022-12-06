using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingTutorial : Tutorial
{
    [SerializeField] private float _scalingDuration = 0.5f;
    [SerializeField] private Ease _ease;
    [SerializeField] private bool _unscaledTime;

    public override void ShowTutorial()
    {
        _tutorialImage.transform.ScaleIn(_ease, _scalingDuration, _unscaledTime);
    }

    public override void HideTutorial()
    {
        _tutorialImage.transform.ScaleOutWithDiactivation(_scalingDuration, _unscaledTime);
    }
}
