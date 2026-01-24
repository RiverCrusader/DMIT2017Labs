using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public List<GameObject> mounts = new List<GameObject>();
    public string mountType;
    public GameObject playerSpawnPoint;
    public Material mountColour;

    PhysicsMovement physMove;
    public SaveMenuInteractivity smi;
    public GhostData ghostData;
    public GhostDataRecorder ghostDataRecorder;

    public void StartRace()
    {
        mountColour.color = smi.colourChoice;

        physMove = transform.GetComponent<PhysicsMovement>();
        transform.SetPositionAndRotation(playerSpawnPoint.transform.position,playerSpawnPoint.transform.rotation);
        

        if(smi.mountTypeToggle[0].isOn == true)
        {
            SpawnMount(0);
            mountType = "Horse";
        }
        if(smi.mountTypeToggle[1].isOn == true)
        {
            SpawnMount(1);
            mountType = "Snake";
        }
        if(smi.mountTypeToggle[2].isOn == true)
        {
            SpawnMount(2);
            mountType = "Dragon";
        }

        ghostDataRecorder.StartRecording();

    }
    void FixedUpdate()
    {
        
    }

    public void SpawnMount(int mountchoice_)
    {
        GameObject instance = Instantiate(mounts[mountchoice_], transform, false);

        if(instance != null)
        {
            transform.SetParent(instance.transform);
        }
    }
    
    public void EndRace(float highScore_)
    {
        ghostDataRecorder.StopRecording();
        smi.highScore = (int)highScore_;
        smi.EndRace();
    }
    
}
