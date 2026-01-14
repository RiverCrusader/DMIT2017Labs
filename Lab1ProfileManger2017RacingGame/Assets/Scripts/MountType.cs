using UnityEngine;

public class MountType : MonoBehaviour
{
    string mountName;
    int mountSpeed;
    int acceloration;
    int offRoadSpeed;
    bool canJump;

    public MountType(string name_, int speed_, int offRoadSpeed_, int acceloration_, bool canJump_)
    {

        mountName = name_;
        mountSpeed = speed_;
        offRoadSpeed = offRoadSpeed_;
        acceloration = acceloration_;
        canJump = canJump_;

    }

}


