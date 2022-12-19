using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeController : MonoBehaviour
{
    public enum Theme
    {
        Bright,
        Dark
    }

    [SerializeField] private Slider _slider;

    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private List<Image> _images;

    [SerializeField] private Color _dark;
    [SerializeField] private Color _bright;

    private void Start()
    {
        ManageCurrentTheme();

        _slider.onValueChanged.AddListener(SliderChanged);
    }

    public void SliderChanged(float value)
    {
        Set((Theme)value);
    }

    private void Set(Theme theme)
    {
        _background.color = theme == Theme.Bright ? _bright : _dark;
        _slider.value = (int)theme;

        foreach (var img in _images)
        {
            img.color = theme == Theme.Bright ? _bright : _dark;
        }

        ProgressManager.SaveValue(Tags.THEME, (int)theme);
    }

    private void ManageCurrentTheme()
    {
        var intValue = (long)ProgressManager.GetValue(Tags.THEME, ((long)Theme.Dark));

        var theme = (Theme)intValue;
        Set(theme);
    }
}
