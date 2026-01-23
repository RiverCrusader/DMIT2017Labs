using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.UI;


public class Titlemanager : MonoBehaviour
{
    [SerializeField] GameObject mainMenucanvas, pauseMenuCanvas;
    [SerializeField] Button startButton;
    bool isPause;

    void Start()
    {
        mainMenucanvas.SetActive(true);
        startButton.interactable = false;

        
    }
    void Update()
    {
      
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
