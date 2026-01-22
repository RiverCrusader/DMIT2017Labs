using UnityEngine;

public class MountType : MonoBehaviour
{
    float mountSpeed;
    float acceloration;
    float offRoadSpeed;
    bool canJump;

    public MountType(float maxSpeed_, float offRoadSpeed_, float acceloration_, bool canJump_)
    {
        mountSpeed = maxSpeed_;
        offRoadSpeed = offRoadSpeed_;
        acceloration = acceloration_;
        canJump = canJump_;

    }
}


