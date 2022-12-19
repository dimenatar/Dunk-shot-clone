using TMPro;
using UnityEngine;

public class PointsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _counter;

    private void Awake()
    {
        HoopsController.BallAdded += AddPoint; 
    }

    private void OnDestroy()
    {
        HoopsController.BallAdded -= AddPoint;
    }

    private void AddPoint()
    {
        _counter++;
        _text.text = $"{_counter}";
    }
}
