using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEditor;

public class Titlemanager : MonoBehaviour
{
    [SerializeField] GameObject mainMenucanvas, pauseMenuCanvas;
    [SerializeField] GameObject defaultPauseMenuButton, defaultMainMenuButton;

    bool isPause;

    void Start()
    {
        mainMenucanvas.SetActive(true);
        pauseMenuCanvas.SetActive(false);

        EventSystem.current.SetSelectedGameObject(defaultMainMenuButton);
    }
    void Update()
    {
       // if(GameManager.instance.menuOpenCloseInput)
        {
            if(!isPause)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }
    
    public void Pause()
    {
        isPause = true;
        Time.timeScale = 0f;

        pauseMenuCanvas.SetActive(true);
        mainMenucanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(defaultPauseMenuButton);
    }

    public void Unpause()
    {
        isPause = false;
        Time.timeScale = 1f;

        pauseMenuCanvas.SetActive(false);
        mainMenucanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultMainMenuButton);
    }

    public void ResumeGame()
    {
        Unpause();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Asteroids");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
