using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

public class SaveSystem : MonoBehaviour
{
    public string filePath; //path to directory
    public List<SaveData> saveDataList = new List<SaveData>();

    void Start()
    {
        // Debug.Log(filePath);
        // string[] lines =
        // {
        //     "Profile Name, Time, Score",
        //     "Jordan, 1000, 10",
        //     "MHWilds, 3035, 17"
        // };

        // File.WriteAllLines(filePath, lines);
        //CreateSave("Jordan", 1000);
        Debug.Log(LoadData("Jordan"));
    }

    public void CreateSave(string profileName_, int highScore_)
    {
        SaveData saveData = new SaveData(profileName_, highScore_);

        bool fileExists = File.Exists(filePath);

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            if (!fileExists)
            {
                writer.WriteLine("Profile Name, Time");
            }

            writer.WriteLine($"{saveData.profileName}, {saveData.highScore}");
            saveDataList.Add(saveData);
        }


    }

    public void UpdateSave(SaveData saveFile_)
    {
        
    }

    public void DeleteSave(SaveData saveFile_)
    {
        
    }

    //CSV = comma seperated file, simple and easy to read outside the editor

    //lots of AAA use Json and incripted XML

    public int LoadData(string profileName_)
    {
        //lines = rows 
        //columns = up down (duhh)

        int loadedHighScore = 0;
        string[] lines = File.ReadAllLines(filePath);

        for(int i = 0; i < lines.Length; i++)
        {
            string[] columns = Regex.Split(lines[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            if(columns[0] == profileName_)
            {
                loadedHighScore = int.Parse(columns[1]);
                i = lines.Length;
            }
            
        }

        SaveData saveData = new SaveData(profileName_, loadedHighScore);
        saveDataList.Add(saveData);
        return loadedHighScore;
    }
}

[Serializable]
public class SaveData
{
    public string profileName;
    public int highScore;

    public SaveData(string profileName_, int highScore_)
    {
        profileName = profileName_;
        highScore = highScore_;
    }
}
