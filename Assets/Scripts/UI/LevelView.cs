using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _level;

    private void Start()
    {
        _level.text = $"LEVEL {ProgressManager.GetCurrentLevelOrder()}";
    }
}
