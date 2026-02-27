using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TittleScreenUIControl : MonoBehaviour
{
    public void NewGame()
    {
        File.Delete("Assets/Resources/save.json");
        LoadGame();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("RPG_World");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
