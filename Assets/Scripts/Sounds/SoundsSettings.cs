using UnityEngine;
using UnityEngine.UI;

public class SoundsSettings : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioSource _audioSource;

    private bool _isEnabled;

    private void Awake()
    {
        LoadSettings();

        _slider.onValueChanged.AddListener((value) => ChangeValue());
    }

    public void ChangeValue()
    {
        _isEnabled = !_isEnabled;
        SetEnabled(_isEnabled);
    }

    private void LoadSettings()
    {
        _isEnabled = (bool) ProgressManager.GetValue(Tags.SOUNDS_ENABLED, true);

        _slider.value = _isEnabled ? 1f : 0f;
        SetEnabled(_isEnabled);
    }

    private void SetEnabled(bool enabled)
    {
        print(enabled);

        _isEnabled = enabled;

        _audioSource.enabled = enabled;

        ProgressManager.SaveValue(Tags.SOUNDS_ENABLED, _isEnabled);
    }
}
