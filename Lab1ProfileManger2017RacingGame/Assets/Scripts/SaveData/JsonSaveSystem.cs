using UnityEngine;
using System.IO;

public class JsonSaveSystem : MonoBehaviour
{
    public string filePath;
    public SaveProfile profileData;
    string profileName;

    [ContextMenu("JSON Save")]

    public void SaveData()
    {
        SaveProfile saveProfile = new SaveProfile("Jordan", 1121);
        string file = $"{filePath}" + $"{profileName}" + ".json";
        string json = JsonUtility.ToJson(saveProfile, true);

        File.WriteAllText(file, json);
    }

    [ContextMenu("JSON Load")]

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            profileData = JsonUtility.FromJson<SaveProfile>(json);
        }

        else
        {
            Debug.LogError("Save file not found");
        }
    }
}

public class SaveProfile
{
    public string profileName;
    public int highScore;

    public SaveProfile(string profileName_, int highScore_)
    {
        profileName = profileName_;
        highScore = highScore_;
    }
}

