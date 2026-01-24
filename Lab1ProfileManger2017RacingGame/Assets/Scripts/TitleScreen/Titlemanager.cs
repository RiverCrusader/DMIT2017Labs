using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Titlemanager : MonoBehaviour
{
    [SerializeField] GameObject mainMenucanvas; //pauseMenuCanvas;
    // [SerializeField] Button startButton;

    public void StartGame()
    {
        SceneManager.LoadScene("RaceTrackScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
