using UnityEngine;
using System.IO;

public class JsonSaveSystem : MonoBehaviour
{
    public string filePath;
    string file;
    public SaveProfile profileData;
    public SaveMenuInteractivity saveMenuInteract;
    public GhostData ghostData;
  
    


    [ContextMenu("JSON Save")]

    public void SaveData()
    {
        SaveProfile saveProfile = new SaveProfile(saveMenuInteract.profileName, saveMenuInteract.highScore, Color.darkMagenta, saveMenuInteract.mountType, ghostData);
        file = filePath + saveMenuInteract.profileName + ".json";

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

