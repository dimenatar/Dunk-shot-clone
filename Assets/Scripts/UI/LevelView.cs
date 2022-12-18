using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _level;

    private const string KEY = "LevelOrder";

    private void Start()
    {
        _level.text = $"LEVEL {ProgressManager.GetValue(KEY, 0)}";
    }
}
