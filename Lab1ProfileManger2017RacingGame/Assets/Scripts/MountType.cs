using UnityEngine;

public class MountType : MonoBehaviour
{
    public float maxSpeed;
    public float offRoadSpeed;
    public bool canJump;
    public enum MountChoice {Horse, Snake, Dragon}
    public MountChoice mount;

    public MountType(float maxSpeed_, float offRoadSpeed_, bool canJump_, MountChoice mount_)
    {
        maxSpeed = maxSpeed_;
        offRoadSpeed = offRoadSpeed_;
        canJump = canJump_;
        mount = mount_;
    }
}
