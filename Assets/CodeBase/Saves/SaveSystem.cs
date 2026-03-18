using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public static class SaveSystem {
    private static string SavePath(string fileName) {
        return Application.persistentDataPath + "/" + fileName + ".json";
    }

    public static void Save<T>(T data, string fileName) {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(SavePath(fileName), json);
    }

    public static T Load<T>(string fileName) where T : new() {
        string path = SavePath(fileName);

        if (!File.Exists(path))
            return new T();

        string json = File.ReadAllText(path);

        return JsonConvert.DeserializeObject<T>(json);
    }

    public static void DeleteSaves(string fileName) {
        string path = SavePath(fileName);

        if (File.Exists(path)) {
            File.Delete(path);
            Debug.Log($"Save file '{fileName}' deleted.");
        }
        else {
            Debug.LogWarning($"Save file '{fileName}' not found.");
        }
    }
}