using System.Collections.Generic;
using UnityEngine;

public class GhostData : MonoBehaviour
{
    public List<GhostDataFrame> ghostDataFrames = new List<GhostDataFrame>();

//can put this into a CSV files ideally seperate Name it ghostData{profileName} type shit
    //index
    // position - need to be split into xyz
    // roataion - need to be split into xyz

    public void AddFrame(Vector3 position_, Vector3 rotation_)
    {
        ghostDataFrames.Add(new GhostDataFrame(position_,rotation_));
    }

}

public class GhostDataFrame
{
    public Vector3 position;
    public Vector3 rotation;

    public GhostDataFrame(Vector3 position_, Vector3 rotation_)
    {
        position = position_;
        rotation = rotation_;
    }
}
