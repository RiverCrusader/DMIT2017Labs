using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveMenuInteractivity : MonoBehaviour
{
    public GameObject canvas;
    public TMP_InputField profileNameField;
    public string profileName;
    public int highScore;
    public TMP_ColorGradient colourChoice;
    //public List<Toggle> mountTypeToggle = new List<Toggle>();
    public ToggleGroup mountTypeToggleGroup;
    public string mountType;

    public Button startRaceButton;
    public JsonSaveSystem jsonSave;
    public GameManager gameManager;


    void Start()
    {
        canvas.SetActive(true);
        startRaceButton.interactable = false;

        profileName = "";
    }

    public void SubmitProfile()
    {
        profileName = profileNameField.text;

        if (profileName != "") startRaceButton.interactable = true;
    }

    public void SaveGameButton()
    {
        Toggle selectedToggle = mountTypeToggleGroup.ActiveToggles().FirstOrDefault();

        if (selectedToggle != null)
        {
            Debug.Log("The selected toggle is: " + selectedToggle.name);

            if(selectedToggle.name == "HorseToggle")
            {
                mountType = "Horse";
            }
            if(selectedToggle.name == "SnakeToggle")
            {
                mountType = "Snake";
            }
            if(selectedToggle.name == "DragonToggle")
            {
                mountType = "Dragon";
            }
        }
        else
        {
            // This case might happen if "Allow Switch Off" is enabled on the Toggle Group
            Debug.Log("No toggle is currently active.");
        }

        if (profileName != "") 
        {
            jsonSave.SaveData();
        }
        
    }

    public void LoadGameButton()
    {
        
    }

    public void DeleteSaveButton(SaveData saveFile_)
    {
        
    }

    public void StartRace()
    {
        canvas.SetActive(false);
        gameManager.SpawnPlayer(mountType);
    }
}
