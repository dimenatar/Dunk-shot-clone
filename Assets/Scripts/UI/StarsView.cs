using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarsView : MonoBehaviour
{
    [SerializeField] private StarController _starController;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        StarController.StarAmountChanged += SetAmount;
        SetAmount(_starController.StarAmount);
    }

    private void OnDestroy()
    {
        StarController.StarAmountChanged -= SetAmount;
    }

    private void SetAmount(int amount)
    {
        _text.text = amount.ToString();
    }
}
