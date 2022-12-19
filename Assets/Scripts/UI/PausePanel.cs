using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Image _panel;

    [SerializeField] private List<TextMeshProUGUI> _texts;
    [SerializeField] private List<Image> _images;

    [SerializeField] private float _fadeAnimationDuration = 0.5f;
    [SerializeField] private float _panelAlpha;

    public void ShowPanel()
    {
        Input.ResetInputAxes();

        _panel.gameObject.SetActive(true);
        ShowImagesAndTexts();

        Time.timeScale = 0f;
    }

    public void HidePanel()
    {
        HideTextsAndImages();
    }

    private void ShowImagesAndTexts()
    {
        _panel.DOAlpha(_panelAlpha, 0f).SetUpdate(true);
        _images.ForEach(image => image.DOAlpha(1, 0f).SetUpdate(true));
        _texts.ForEach(text => text.DOAlpha(1, 0f).SetUpdate(true));
    }

    private void HideTextsAndImages()
    {
        _panel.DOAlpha(0, _fadeAnimationDuration).SetUpdate(true);
        _images.ForEach(image => image.DOAlpha(0, _fadeAnimationDuration).SetUpdate(true).onComplete += ImageHided);
        _texts.ForEach(text => text.DOAlpha(0, _fadeAnimationDuration).SetUpdate(true));
    }

    private void ImageHided()
    {
        Time.timeScale = 1f;

        _panel.gameObject.SetActive(false);
    }
}
