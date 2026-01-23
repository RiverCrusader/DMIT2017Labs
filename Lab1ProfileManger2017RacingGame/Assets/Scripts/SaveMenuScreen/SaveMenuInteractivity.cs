using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMenuInteractivity : MonoBehaviour
{
    public GameObject canvas;
    public InputField profileNameField;
    public string profileName;
    public Color colourChoice;
    public List<Toggle> mountType = new List<Toggle>();

    public Button startRaceButton;
    JsonSaveSystem jsonSave;


    void Start()
    {
        canvas.SetActive(true);

        profileName = "";
    }


    public void SubmitProfile()
    {
        profileName = profileNameField.text;

        if (profileName != "") startRaceButton.interactable = true;
    }

    public void SaveGameButton()
    {
        if (profileName != "") jsonSave.SaveData();


        
    }

    public void DeleteSaveButton(SaveData saveFile_)
    {
        
    }

    public void StartRace()
    {
        canvas.SetActive(false);
    }
}
