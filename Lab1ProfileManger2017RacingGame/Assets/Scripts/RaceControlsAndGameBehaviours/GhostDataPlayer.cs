using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GhostDataPlayer : MonoBehaviour
{
    GameManager gameManager;
    public GameObject ghostRacer;
    public GhostData ghostData = new GhostData();
    
    public int frameCount = 0;

    public void RetrieveGhostData(GhostData ghostData_, Color colour_)
    {
        foreach(GhostDataFrame tmp in ghostData_.ghostDataFrames)
        {
            ghostData.AddFrame(tmp.position, tmp.rotation);
        }

        frameCount = 0;
        colour_.a = 0.5f;
        
        //ghostRacer.GetComponentInChildren<Renderer>().material.color = colour_;
    }

    void FixedUpdate()
    {
        if(ghostData != null)
        {
            if(ghostData.ghostDataFrames.Count > 0 && ghostData.ghostDataFrames.Count > frameCount)
            {
                transform.position = ghostData.ghostDataFrames[frameCount].position;
                transform.eulerAngles = ghostData.ghostDataFrames[frameCount].rotation;
                frameCount++; 
            }
        }
    }
}
