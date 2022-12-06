using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private AnimationCurve _curve;

    [SerializeField] private float _duration = 1.5f;

    public virtual void Animate(int startAmount, int target)
    {
        if (startAmount < target)
        {
            StartCoroutine(AnimateTextUp(_text, startAmount, target, _duration, _curve));
        }
        else
        {
            StartCoroutine(AnimateTextDown(_text, startAmount, target, _duration, _curve));
        }
    }

    protected virtual IEnumerator AnimateTextUp(Text text, int startAmount, int amount, float duration, AnimationCurve curve)
    {
        float timer = 0f;
        int current = startAmount;
        text.text = $"{current:0}";
        while (timer < duration)
        {
            current = (int)(curve.Evaluate(timer / duration) * amount);

            text.text = $"{current:0}";

            timer += Time.unscaledDeltaTime;

            yield return null;
        }
        text.text = $"{amount:0}";
    }

    protected virtual IEnumerator AnimateTextDown(Text text, int startAmount, int amount, float duration, AnimationCurve curve)
    {
        float timer = 0f;
        int current = startAmount;
        text.text = $"{current:0}";
        while (timer < duration)
        {
            current = (int)(curve.Evaluate(1 - timer / duration) * current);

            text.text = $"{current:0}";

            timer += Time.unscaledDeltaTime;

            yield return null;
        }
        text.text = $"{amount:0}";
    }
}
