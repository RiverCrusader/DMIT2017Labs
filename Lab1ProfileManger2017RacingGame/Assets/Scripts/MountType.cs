using UnityEngine;

public class MountType : MonoBehaviour
{
    public float maxSpeed;
    public float offRoadSpeed;
    public bool canJump;

    public MountType(float maxSpeed_, float offRoadSpeed_, bool canJump_)
    {
        maxSpeed = maxSpeed_;
        offRoadSpeed = offRoadSpeed_;
        canJump = canJump_;
    }
}
