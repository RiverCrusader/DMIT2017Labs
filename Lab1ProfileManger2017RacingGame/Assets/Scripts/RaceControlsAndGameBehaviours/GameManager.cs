using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public PlayerControl playerControl;
    public GhostDataPlayer ghostDataPlayer;
    GameObject player, ghostPlayer;
    public GhostData playerGhostData;
    float highscore;

    float startTime = 0, endTime = 0;


    public InputAction endRace;

    void Start()
    {
        endRace.Enable();

        endRace.performed += ForceEndRace;
        endRace.canceled += ForceEndRace;

    }

    public void StartRace()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //playerGhostData.ghostDataFrames = player.GetComponent<GhostData>().ghostDataFrames;

        if(playerGhostData != null)
        {
            GameObject instance = Instantiate(ghostDataPlayer.gameObject);
            ghostDataPlayer.RetrieveGhostData(playerGhostData, playerControl.mountColour.color);
        }

        playerControl.StartRace();
        startTime = Time.time;
    }
    
    [ContextMenu("End Race")]
    public void EndRace()
    {
        endTime = Time.time;
        highscore = (endTime - startTime) * 100;


        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player);

        ghostPlayer = GameObject.FindGameObjectWithTag("GhostPlayer");
        Destroy(ghostPlayer);

        playerControl.EndRace(highscore);
    }

    public void ForceEndRace(InputAction.CallbackContext c)
    {
        EndRace();
    }
}
