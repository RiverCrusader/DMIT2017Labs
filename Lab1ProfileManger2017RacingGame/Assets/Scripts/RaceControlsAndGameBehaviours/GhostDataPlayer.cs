using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GhostDataPlayer : MonoBehaviour
{
    GameManager gameManager;
    GhostData ghostData;

    public GameObject ghostRacer;

    public void RetrieveGhostData(GhostData ghostData_, Color colour_)
    {
        ghostData = ghostData_;

        colour_.a = 0.5f;
        ghostRacer.GetComponent<Renderer>().material.color = colour_;
    }

    void FixedUpdate()
    {
        if(ghostData != null)
        {
            foreach(GhostDataFrame tmp in ghostData.ghostDataFrames)
            {
                transform.position = tmp.position;
                transform.eulerAngles = tmp.rotation;
            }
        }
    }
}
