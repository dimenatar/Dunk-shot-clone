using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsRecordController : MonoBehaviour
{
    [SerializeField] private HoopsController _hoopsController;

    public static event Action<int> PointsRecordUpdated;

    private int _loadedRecord;

    private void Awake()
    {
        LevelEnder.LevelEnded += SaveRecord;
    }

    private void Start()
    {
        LoadRecord();
    }

    private void OnDestroy()
    {
        LevelEnder.LevelEnded -= SaveRecord;
    }

    private void LoadRecord()
    {
        _loadedRecord = (int)(long)ProgressManager.GetValue(Tags.POINTS_RECORD, 0);

        PointsRecordUpdated?.Invoke(_loadedRecord);
    }

    private void SaveRecord()
    {
        var points = _hoopsController.Index;

        if (points > _loadedRecord)
        {
            ProgressManager.SaveValue(Tags.POINTS_RECORD, points);
        }
    }
}
