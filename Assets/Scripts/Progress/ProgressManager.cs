using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    private static UserData _userData;

    private void Awake()
    {
        _userData = LoadUserData();
        print(UserDataSerializer<UserData>.Path);
    }

    public static int GetCurrentLevelOrder()
    {
        return _userData.CurrentLevelOrder;
    }

    public static string GetCurrentSceneName()
    {
        print(_userData);
        return _userData.CurrentSceneName;
    }

    public bool IsCompletedAllLevels()
    {
        return _userData.IsCompletedAllLevels;
    }

    public static bool HasKey(string key)
    {
        return _userData.Keys.Contains(key);
    }

    public static void SaveKey(string key)
    {
        _userData.Keys.Add(key);
    }

    private UserData LoadUserData()
    {
        var userData = UserDataSerializer<UserData>.LoadUserData();

        if (userData == null)
        {
            userData = new UserData();

            UserDataSerializer<UserData>.SaveUserData(userData);
        }

        return userData;
    }


    private void UpdateUserData()
    {
        UserDataSerializer<UserData>.SaveUserData(_userData);
    }
}
