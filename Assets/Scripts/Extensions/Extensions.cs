using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class Extensions
{
    /// <summary>
    /// Moves particles to a given destination and plays it
    /// </summary>
    /// <param name="particles"></param>
    /// <param name="position"></param>
    public static void Play(this ParticleSystem particles, Vector3 position)
    {
        particles.transform.position = position;
        particles.Play();
    }

    /// <summary>
    /// Scale diactivated transform to it's localScale with activation
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="duration"></param>
    /// <param name="update"></param>
    public static Tween ScaleIn(this Transform transform, Ease? ease = null, float duration = 0.5f, bool update = false)
    {
        Vector3 savedScale = transform.localScale != Vector3.zero ? transform.localScale : Vector3.one;

        transform.localScale = Vector3.zero;

        transform.gameObject.SetActive(true);
        if (ease == null)
        {
            return transform.DOScale(savedScale, duration).SetUpdate(update);
        }
        else
        {
            return transform.DOScale(savedScale, duration).SetEase(ease.Value).SetUpdate(update);
        }
    }

    public static void ScaleIn(this Transform transform, Tweener tween, float duration = 0.5f)
    {
        Vector3 savedScale = transform.localScale;
        transform.localScale = Vector3.zero;

        transform.gameObject.SetActive(true);
        //transform.DOScale(savedScale, duration);
        tween.Play();
    }



    public static Tween ScaleOutWithDiactivation(this Transform transform, float duration = 0.5f, bool update = false) =>
        transform.DOScale(0, duration).SetUpdate(update).OnComplete(() => transform.gameObject.SetActive(false));

    /// <summary>
    /// Changes image alpha
    /// </summary>
    /// <param name="image"></param>
    /// <param name="alpha"></param>
    /// <param name="duration"></param>
    public static Tween DOAlpha(this Image image, float alpha, float duration = 0.5f)
    {
        return image.DOColor(GetColorWithAlpha(image.color, alpha), duration);
    }

    public static Tween DOAlpha(this TextMeshProUGUI text, float alpha, float duration = 0.5f)
    {
        return text.DOColor(GetColorWithAlpha(text.color, alpha), duration);
    }

    public static Tween DOPulse(this Transform transform, float minScale = 1, float maxScale = 1.2f, float scaleInDuration = 0.25f, float scaleOutDuration = 0.25f, int loops = -1, bool update = false)
    {
        var sequence = DOTween.Sequence();

        return   sequence
                .Append(transform.DOScale(maxScale, scaleInDuration))
                .Append(transform.DOScale(minScale, scaleOutDuration))
                .SetLoops(loops, LoopType.Restart)
                .SetUpdate(update);
    }

    public static Color SetAlpha(this Color color, float alpha)
    {
        color.a = alpha;
        return color;
    }

    private static Color GetColorWithAlpha(Color color, float alpha)
    {
        color.a = alpha;
        return color;
    }

    public static Texture2D ChangeFormat(this Texture2D oldTexture, TextureFormat newFormat)
    {
        //Create new empty Texture
        Texture2D newTex = new Texture2D(2, 2, newFormat, false);
        //Copy old texture pixels into new one
        newTex.SetPixels(oldTexture.GetPixels());
        //Apply
        newTex.Apply();

        return newTex;
    }

    public static IEnumerable<T> FindInterfacesOfType<T>(bool includeInactive = false)
    {
        return SceneManager.GetActiveScene().GetRootGameObjects()
                .SelectMany(go => go.GetComponentsInChildren<T>(includeInactive));
    }

    public static T GetRandom<T>(this List<T> source, Func<T, bool> selector)
    {
        var result = source.Where(item => selector(item)).ToList();
        return result[UnityEngine.Random.Range(0, result.Count())];
    }

    public static T GetRandom<T>(this List<T> list) => list[UnityEngine.Random.Range(0, list.Count)];

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;

        float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg + 90;
        return angle < 0 ? angle + 360 : angle;
    }

    public static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    public static Vector2 Parabola(Vector2 start, Vector2 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector2.Lerp(start, end, t);

        return new Vector2(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t));
    }

    public static void SetLocalPositionAndRotation(this Transform transform, Vector3 position, Quaternion rotation)
    {
        transform.localPosition = position;
        transform.localRotation = rotation;
    }

    public static void Clear(this LineRenderer lineRenderer)
    {
        lineRenderer.positionCount = 0;
    }

    public static bool IsInLayerMask(this LayerMask layerMask, int layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }

    public static void SetLayer(this GameObject gameObject, int layer, bool includeChildren)
    {
        if (!includeChildren)
        {
            gameObject.layer = layer;
            return;
        }

        gameObject.GetComponents<Transform>().ToList().ForEach(child => child.gameObject.layer = layer);
    }

    public static IEnumerable<float> FloatRange(float min, float max, float step)
    {
        for (float value = min; value <= max; value += step)
        {
            yield return value;
        }
    }
}

