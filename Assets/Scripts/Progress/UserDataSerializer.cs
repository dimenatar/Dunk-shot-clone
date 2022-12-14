using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public static class UserDataSerializer<T>
{
    public static string Path { get; } = Application.persistentDataPath + "//SaveData.json";
    

    public static T LoadUserData(string path)
    {
        return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
    }

    public static T LoadUserData()
    {
        return File.Exists(Path) ? JsonConvert.DeserializeObject<T>(File.ReadAllText(Path)) : default;
    }

    public static void SaveUserData(string path, T data)
    {
        File.WriteAllText(path, JsonConvert.SerializeObject(data));
    }

    public static void SaveUserData(T data)
    {
        File.WriteAllText(Path, JsonConvert.SerializeObject(data));
    }
}
