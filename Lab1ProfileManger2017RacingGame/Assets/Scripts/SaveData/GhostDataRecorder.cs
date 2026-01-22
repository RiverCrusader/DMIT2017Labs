using UnityEngine;

public class GhostDataRecorder : MonoBehaviour
{
    public GhostData ghostData = new GhostData();
    private bool recording;

    void Start()
    {
        StartRecording();
    } 
    
    public void StartRecording()
    {
        recording = true;
    }


    void FixedUpdate()
    {
        if(!recording) return;

        ghostData.AddFrame(transform.position, transform.eulerAngles);

    }
}
