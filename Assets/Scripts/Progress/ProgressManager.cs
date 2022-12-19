using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private const string LEVEL_ORDER = "LevelOrder";
    private const string LEVEL_NAME = "LevelName";
    private const string IS_COMPLETED_ALL_LEVELS = "IsCompletedAllLevels";

    private static Dictionary<string, object> _pairs;

    private void Awake()
    {
        _pairs = LoadUserData();
        UpdateUserData();
    }

    private void OnDestroy()
    {
        UpdateUserData();
    }

    public static object GetValue(string tag, object defaultValue = null)
    {
        if (!_pairs.ContainsKey(tag))
        {
            _pairs.Add(tag, defaultValue);
        }

        return _pairs[tag];
    }

    public static void SaveValue(string tag, object value)
    {
        //_userData.SetItem(tag, value);

        if (_pairs.ContainsKey(tag))
        {
            _pairs[tag] = value;
        }
        else
        {
            _pairs.Add(tag, value);
        }
    }

    public static bool ContainsKey(string key)
    {
        return _pairs.ContainsKey(key);
    }

    private Dictionary<string, object> LoadUserData()
    {
        //var userData = UserDataSerializer<UserData>.LoadUserData();
        //
        //if (userData == null)
        //{
        //    userData = new UserData();
        //
        //    UserDataSerializer<UserData>.SaveUserData(userData);
        //}
        //
        //return userData;

        var data = UserDataSerializer<Dictionary<string, object>>.LoadUserData();

        if (data == null)
        {
            data = new Dictionary<string, object>();
            UpdateUserData();
        }

        return data;
    }


    private void UpdateUserData()
    {
        UserDataSerializer<Dictionary<string, object>>.SaveUserData(_pairs);
    }
}
