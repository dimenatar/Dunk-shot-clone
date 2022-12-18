using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private int _starAmount;

    private const string STAR_AMOUNT = "StarAmount";

    public static event Action<int> StarAmountChanged;

    public int StarAmount 
    { 
        get => _starAmount; 
        set
        {
            _starAmount = value;

            StarAmountChanged?.Invoke(_starAmount);

            ProgressManager.SaveValue(STAR_AMOUNT, value);
        }
    }

    private void Awake()
    {
        HoopStar.StarCollected += AddStar;
    }

    private void Start()
    {
        print(ProgressManager.GetValue(STAR_AMOUNT, 0));
        StarAmount = int.Parse(ProgressManager.GetValue(STAR_AMOUNT, 0).ToString());
    }

    private void OnDestroy()
    {
        HoopStar.StarCollected -= AddStar;
    }

    public bool SpendStars(int amount)
    {
        if (StarAmount >= amount)
        {
            StarAmount -= amount;
            return true;
        }
        return false;
    }

    private void AddStar()
    {
        StarAmount++;
    }
}
