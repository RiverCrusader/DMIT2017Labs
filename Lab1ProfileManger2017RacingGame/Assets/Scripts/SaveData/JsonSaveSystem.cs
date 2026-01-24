using UnityEngine;
using System.IO;
using UnityEditor.Build.Content;

public class JsonSaveSystem : MonoBehaviour
{
    public string filePath;
    string file;
    public SaveProfile profileData;
  

    [ContextMenu("JSON Save")]

    public void SaveData(string profileName_, int highScore_, Color colour_, string mountType_, GhostData ghostData_)
    {
        SaveProfile saveProfile = new SaveProfile(profileName_, highScore_, colour_, mountType_, ghostData_);
        file = filePath + profileName_ + ".json";

        string json = JsonUtility.ToJson(saveProfile, true);

        File.WriteAllText(file, json);
    }

    [ContextMenu("JSON Load")]

    public void LoadData(string profileName_)
    {
        file = filePath + profileName_ + ".json";

        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);

            profileData = JsonUtility.FromJson<SaveProfile>(json);
        }

        else
        {
            Debug.LogError("Save file not found");
        }
    }

    public void DeleteData(string profileName_)
    {
        
    }
}

public class SaveProfile
{
    public string profileName;
    public int highScore;
    public Color colour;
    public string mount;

    public GhostData ghostData;

    public SaveProfile(string profileName_, int highScore_, Color colour_, string mount_, GhostData ghostData_)
    {
        profileName = profileName_;
        highScore = highScore_;
        colour = colour_;
        mount = mount_;
        ghostData = ghostData_;

    }
}

