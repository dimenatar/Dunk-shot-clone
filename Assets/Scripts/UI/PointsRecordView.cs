using TMPro;
using UnityEngine;

public class PointsRecordView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        PointsRecordController.PointsRecordUpdated += SetValue;
    }

    private void OnDestroy()
    {
        PointsRecordController.PointsRecordUpdated -= SetValue;
    }

    private void SetValue(int value)
    {
        _text.text = value.ToString();
    }
}
