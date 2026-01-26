using UnityEngine;
using System.IO;

public class JsonSaveSystem : MonoBehaviour
{
    public string filePath;
    string file;
    public SaveProfile profileData;
    //bool fileExists = false;
  

    [ContextMenu("JSON Save")]

    public void SaveData(string profileName_, int highScore_, Color colour_, string mountType_, GhostData ghostData_)
    {
        SaveProfile saveProfile = new SaveProfile(profileName_, highScore_, colour_, mountType_, ghostData_);

        file = Application.persistentDataPath + "/" /*+ filePath */ + profileName_ + ".json";

        string json = JsonUtility.ToJson(saveProfile, true);

        File.WriteAllText(file, json);
    }

    [ContextMenu("JSON Load")]

    public void LoadData(string profileName_)
    {
        file = Application.persistentDataPath + "/" /*+ filePath */ + profileName_ + ".json";

        if (File.Exists(file))
        {
            //fileExists = true;
            string json = File.ReadAllText(file);

            profileData = JsonUtility.FromJson<SaveProfile>(json);
        }
        else
        {
            Debug.Log("Save file not found");
            //fileExists = false;
        }
    }

    public void DeleteData(string profileName_)
    {
        file = Application.persistentDataPath + "/"/*+ filePath */ + profileName_ + ".json";

        if(File.Exists(file))
        {
            //fileExists = true;
            File.Delete(file);
        }
        else
        {
            //fileExists = false;
            Debug.Log("Save file not found");
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

