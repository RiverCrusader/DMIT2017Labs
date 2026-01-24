using System.Collections.Generic;
// using System.Linq;
using TMPro;
using UnityEngine;
// using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.IO;

public class SaveMenuInteractivity : MonoBehaviour
{
    public GameObject canvas;

    [Header("Save Data")]
    string file;
    public TMP_InputField profileNameField;
    public string profileName;
    public int highScore;
    public TMP_Text highScoreDisplay;
    public TMP_Text deletionConfirmation;
    bool messageShowing;
    public FlexibleColorPicker fcp;
    public Color colourChoice;
    public List<Toggle> mountTypeToggle = new List<Toggle>();
    //public ToggleGroup mountTypeToggleGroup;
    public string mountType;
    public PlayerControl player;
    public JsonSaveSystem jsonSave;

    [Header("Buttons and Managers")]
    public Button startRaceButton;
    public Button saveButton, loadSaveButton, deleteSaveButton;
    public GameManager gameManager;


    void Start()
    {
        canvas.SetActive(true);
        startRaceButton.interactable = false;

        deletionConfirmation.enabled = false;
        messageShowing = false;

        saveButton.interactable = false;
        loadSaveButton.interactable = false;
        deleteSaveButton.interactable = false;


        profileName = "";
    }
    void FixedUpdate()
    {
        highScoreDisplay.text = $"{highScore}";
    }

    public void SubmitProfile()
    {
        profileName = profileNameField.text;

        if (profileName != "") 
        {
            startRaceButton.interactable = true;

            saveButton.interactable = true;
            loadSaveButton.interactable = true;
            deleteSaveButton.interactable = true;
        }
        
        deletionConfirmation.enabled = false;
    }

    public void SaveGameButton()
    {
        
        if(mountTypeToggle[0].isOn == true)
        {
            mountType = "Horse";
        }
        if(mountTypeToggle[1].isOn == true)
        {
            mountType = "Snake";
        }
        if(mountTypeToggle[2].isOn == true)
        {
            mountType = "Dragon";
        }

        //load colour choice from flexible colour picker 
        //made by: Ward Dehairs, Asset store link -> https://assetstore.unity.com/packages/tools/gui/flexible-color-picker-150497
        colourChoice = fcp.color;

        if (profileName != "") 
        {
            jsonSave.SaveData(profileName, highScore, colourChoice, mountType, player.ghostDataRecorder.ghostData);
        }
        
    }

    public void LoadGameButton()
    {
        jsonSave.LoadData(profileName);

        file = jsonSave.filePath + profileName + ".json";

        if(File.Exists(file))
        {
            highScore = jsonSave.profileData.highScore;
            colourChoice = jsonSave.profileData.colour;
            profileName = jsonSave.profileData.profileName;

            gameManager.ghostData = jsonSave.profileData.ghostData;
            
            if (jsonSave.profileData.mount == "Horse")
            {
                mountTypeToggle[0].isOn = true;
            }
            if (jsonSave.profileData.mount == "Snake")
            {
                mountTypeToggle[1].isOn = true;
            }
            if (jsonSave.profileData.mount == "Dragon")
            {
                mountTypeToggle[2].isOn = true;
            }

            fcp.color = colourChoice;
        }
        else
        {
            
            deletionConfirmation.text = "Profile Dosnt Exist";
            deletionConfirmation.fontStyle = FontStyles.Bold;
            deletionConfirmation.enabled = true;
        }
    }

    public void DeleteSaveButton()
    {
        file = jsonSave.filePath + profileName + ".json";

        if(!File.Exists(file))
        {
            deletionConfirmation.text = "Profile Dosnt Exist";
            deletionConfirmation.fontStyle = FontStyles.Bold;
            deletionConfirmation.enabled = true;
            messageShowing = false;
        }

        if(messageShowing && File.Exists(file))
        {
            jsonSave.DeleteData(profileName);
            deletionConfirmation.text = "Profile Deleted";
            deletionConfirmation.fontStyle = FontStyles.Bold;
        }

        if(!messageShowing && File.Exists(file))
        {
            deletionConfirmation.text = "Are you sure you want to delete your save file?";
            deletionConfirmation.fontStyle = FontStyles.Bold;
            deletionConfirmation.enabled = true;
            
            messageShowing = true;
        } 
    }

    public void StartRace()
    {
        canvas.SetActive(false);
        gameManager.StartRace();
    }
    public void EndRace()
    {
        canvas.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
