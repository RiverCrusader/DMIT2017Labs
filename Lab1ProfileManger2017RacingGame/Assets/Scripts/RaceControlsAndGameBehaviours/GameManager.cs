using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerControl playerControl;
    public GhostDataPlayer ghostDataPlayer;
    GameObject player;
    public GhostData playerGhostData;
    float highscore;

    float startTime = 0, endTime = 0;
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
        Destroy(player);

        playerControl.EndRace(highscore);
    }
}
