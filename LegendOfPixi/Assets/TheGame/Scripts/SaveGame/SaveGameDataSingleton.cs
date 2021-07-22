using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGameDataSingleton
{
    public static SaveGameDataSingleton instance = LoadOrNew();

    public Inventory inventory = new Inventory();

    public Health health = new Health();

    public string SavePoint = string.Empty;

    public List<string> DeletedObjects = new List<string>();

    public SaveGameDataSingleton()
    {
        inventory = new Inventory();
    }

    internal void RecoverDestroy(GameObject gameObject)
    {
        if (DeletedObjects.Contains($"{gameObject.scene.name}.{gameObject.name}"))
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }

    public void Save()
    {
        string data = JsonUtility.ToJson(this);
        string filePath = Path.Combine(Application.persistentDataPath, "savegame.json");
        File.WriteAllText(filePath, data);
        Debug.Log($"{filePath}{Environment.NewLine}{data}");

        var dialogsRenderer = UnityEngine.Object.FindObjectOfType<DialogsRenderer>();
        dialogsRenderer.ShowSavedInformationPanel();
    }

    private static SaveGameDataSingleton LoadOrNew()
    {
        SaveGameDataSingleton saveGameData = new SaveGameDataSingleton();
        string filePath = Path.Combine(Application.persistentDataPath, "savegame.json");
        string data = "new";
        if (File.Exists(filePath))
        {
            data = File.ReadAllText(filePath);
            saveGameData = JsonUtility.FromJson<SaveGameDataSingleton>(data);
        }

        Debug.Log($"{filePath}{Environment.NewLine}{data}");

        return saveGameData;
    }

    public void RecordDestroy(GameObject gameObject, bool recordDestroy)
    {
        DeletedObjects.Add($"{gameObject.scene.name}.{gameObject.name}");
        UnityEngine.Object.Destroy(gameObject);
    }
}
