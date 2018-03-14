using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public static class SaveManager{

    public static void Save<T>(T toSaveObject, string name)
    {
        string path = Application.streamingAssetsPath + "/";
        string jsonString = JsonUtility.ToJson(toSaveObject);
        File.WriteAllText(path+name, jsonString);
    }

    public static T LoadObject<T>(string name) {
        string path = Application.streamingAssetsPath + "/";
        string jsonString = File.ReadAllText(path+name);
        var Obiekt = JsonUtility.FromJson<T>(jsonString);
        return (T)Convert.ChangeType(Obiekt, typeof(T));
    }
    
    public static string CreateJsonString<T>(T obiekt)
    {
        return JsonUtility.ToJson(obiekt);
    }

    public static void SaveToFile(string stringToSave, string name) {
        string path = Application.streamingAssetsPath + "/" + name;
        File.WriteAllText(path, stringToSave);
    }
}