using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.UI;

public class Titlemanager : MonoBehaviour
{
    [SerializeField] GameObject mainMenucanvas, pauseMenuCanvas;
    [SerializeField] Button startButton;
    [SerializeField] InputField profileNameField;

    string profileName;

    bool isPause;

    void Start()
    {
        mainMenucanvas.SetActive(true);
        startButton.interactable = false;

        profileName = "";
    }
    void Update()
    {
      
    }
    
    public void SubmitProfile()
    {
        profileName = profileNameField.text;

        if (profileName != "") startButton.interactable = true;

    }

    public void StartGame()
    {
        SceneManager.LoadScene("RaceTrackScene");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
