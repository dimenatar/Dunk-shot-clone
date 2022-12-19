using UnityEngine;

public class ResolutionPositionsScaler
{
    private const float _baseRatio = (float)1920 / 1080;

    public static float GetNormilizedXPosition(float x)
    {
        var sign = Mathf.Sign(x);
        var newRatio = (float)Screen.height / Screen.width;

        x = (Mathf.Abs(x) - (newRatio - _baseRatio)) * sign;
        return x;
    }
}
