susing DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelAnimations : MonoBehaviour
{
    [SerializeField] private List<Transform> _objectsToShow;

    [SerializeField] private float _delayToShowNewStar = 0.25f;
    [SerializeField] private float _starScaleInDuration = 0.5f;
    [SerializeField] private float _pulseMagnitude = 1.1f;

    public void ShowAnimation()
    {
        StartCoroutine(ShowStarsDelayed(_objectsToShow, _delayToShowNewStar, _starScaleInDuration, _pulseMagnitude));
    }

    private IEnumerator ShowStarsDelayed(List<Transform> stars, float delayToShowNewStar, float scaleInDuration, float pulseMagnitude)
    {
        var delay = new WaitForSecondsRealtime(delayToShowNewStar);

        foreach (var star in stars)
        {
            star.ScaleIn(Ease.OutBack, scaleInDuration, true);

            yield return delay;
        }

        foreach (var star in stars)
        {
            star.DOPulse(update: true);

        }
    }
}
