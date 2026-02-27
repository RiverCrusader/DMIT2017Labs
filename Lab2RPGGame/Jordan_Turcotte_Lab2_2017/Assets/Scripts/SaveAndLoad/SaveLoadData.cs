using UnityEngine;
using System.IO;
using System;

public class SaveLoadData : MonoBehaviour
{
    //Json saves cannot save Dictionaries or SO
    public string filePath;
    
    //public SaveData profileData;

    [ContextMenu("JSON Save")]

    public void SaveData()
    {
        
        string file = "Assets/Resources/save.json";
        string json = JsonUtility.ToJson(GameStateManager.Instance.gameState, true);

        File.WriteAllText(file, json);
        
    }

    [ContextMenu("JSON Load")]

    public void LoadData()
    {
        string s = "Assets/Resources/save.json";
        if (File.Exists(s))
        {
            string json = File.ReadAllText(s);

            GameStateManager.Instance.gameState = JsonUtility.FromJson<GameState>(json);
        }

        else
        {
            //SaveData();
            Debug.Log("Save file not found");
        }
    }
}

// [Serializable]
// public class SaveData
// {
//     public string profileName;
//     public MapState mapState;

//     public SaveData(string profileName_, MapState mapState_)
//     {
//         profileName = profileName_;
//         mapState = mapState_;
//     }
// }
