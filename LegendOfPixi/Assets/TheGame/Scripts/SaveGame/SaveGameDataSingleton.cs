using System;
using System.IO;
using UnityEngine;

public class SaveGameDataSingleton
{
    public static SaveGameDataSingleton instance = new SaveGameDataSingleton();

    public Inventory inventory = new Inventory();

    public Health health = new Health();

    public SaveGameDataSingleton()
    {
        inventory = new Inventory();
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
}
