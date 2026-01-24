using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerControl playerControl;
    public GhostDataPlayer ghostDataPlayer;
    public GhostData ghostData;
    float highscore;

    float startTime = 0, endTime = 0;
    public void StartRace()
    {
        playerControl.StartRace();
        ghostDataPlayer.RetrieveGhostData(ghostData, playerControl.mountColour.color);
        
        startTime = Time.time;
    }
    public void EndRace()
    {
        endTime = Time.time;
        highscore = (startTime - endTime) * 10;

        playerControl.EndRace(highscore);
    }
}
