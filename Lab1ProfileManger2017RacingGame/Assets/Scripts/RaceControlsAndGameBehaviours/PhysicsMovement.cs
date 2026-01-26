using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PhysicsMovement : MonoBehaviour
{
    //add another type of obstacles reduce speed for duration of time
    //build map
    //add deceloration
    
    public InputAction acceloration;
    public InputAction brake;
    public InputAction steering;
    public InputAction jump;

    private Rigidbody rb;


    public float accelorationValue;
    public float brakeValue;
    public float steerValue;
    public float jumpValue;

    //public float decelerationValue = 4.0f;


    public float currentSpeed;
    public float currentMaxSpeed;
    public float maxSpeed;
    public float offRoadMaxSpeed;

    const float ACCELORATION_FACTOR = 15.0f;
    const float BRAKE_FACTOR = 15.0f;
    const float STEER_FACTOR = 30.0f;
    const float JUMP_FORCE = 30.0f;

    PlayerControl playerControl;
    bool canJump = false;
    bool grounded = true;

    //public UnityEvent OnRaceStarted;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        playerControl = GetComponentInParent<PlayerControl>();

        acceloration.Enable();
        brake.Enable();
        steering.Enable();
        jump.Enable();


        acceloration.performed += AccelorationInput;
        acceloration.canceled += AccelorationInput;

        brake.performed += BrakeInput;
        brake.canceled += BrakeInput;

        steering.performed += SteeringInput;
        steering.canceled += SteeringInput;

        jump.performed += JumpInput;
        jump.canceled += JumpInput;

        if(playerControl.mountType == "Dragon")
        {
            canJump = true;
        }

        // //create the different mounts
        // MountType horse = new MountType(horseMaxSpeed, offRoadMaxSpeed, false, MountType.MountChoice.Horse);
        // MountType snake = new MountType(maxSpeed, snakeOffRoadMaxSpeed, false, MountType.MountChoice.Snake);
        // MountType dragon = new MountType(maxSpeed,offRoadMaxSpeed, true, MountType.MountChoice.Dragon);
    }

    public void AccelorationInput(InputAction.CallbackContext c)
    {
        accelorationValue = c.ReadValue<float>() * ACCELORATION_FACTOR;
    }
    public void BrakeInput(InputAction.CallbackContext c)
    {
        brakeValue = c.ReadValue<float>() * BRAKE_FACTOR;
    }
    public void SteeringInput(InputAction.CallbackContext c)
    {
        steerValue = c.ReadValue<float>() * STEER_FACTOR;
    }

    public void JumpInput(InputAction.CallbackContext c)
    {
        jumpValue = c.ReadValue<float>() * JUMP_FORCE;
    }

    private void FixedUpdate()
    {
        float currentSpeed = rb.linearVelocity.magnitude;

        if (accelorationValue > 0f)
        {
            rb.AddForce(transform.forward * accelorationValue, ForceMode.Acceleration);
        }

        if (brakeValue < 0f)
        {
            rb.AddForce(transform.forward * brakeValue, ForceMode.Acceleration);
        }

        // && mount == mount.MountChoice.Dragon
        if(jumpValue > 0f && canJump && grounded)
        {
            rb.AddForce(transform.up * jumpValue, ForceMode.Force);
        }

        
        if (currentSpeed > 0.1f || currentSpeed < -0.1f)
        {
            float steerAmount = steerValue * Mathf.Sign(Vector3.Dot(rb.linearVelocity, transform.forward));
            transform.Rotate(0f, steerAmount * Time.fixedDeltaTime, 0f);
        }

        if (currentSpeed > currentMaxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * currentMaxSpeed;
        }

        if (currentSpeed <= 0 && brakeValue > 0f)
        {
            rb.AddForce(-transform.forward * brakeValue, ForceMode.Acceleration);
        }
    }

    public void SpeedBoost(float boost)
    {
        StartCoroutine(BoostTimer(boost, 5.0f));
    }

    private IEnumerator BoostTimer(float boost_, float duraction_)
    {
        currentSpeed += boost_;
        currentMaxSpeed += boost_ * 2;

        yield return new WaitForSeconds(duraction_);

        currentSpeed -= boost_;
        currentMaxSpeed -= boost_ * 2;
    }

    void OnTriggerEnter(Collider other)
    {
        grounded = true;

        if(other.CompareTag("Ground"))
        {
            currentMaxSpeed = maxSpeed;
        }
        if(other.CompareTag("OffRoad"))
        {
            currentMaxSpeed = offRoadMaxSpeed;
        }
    }
    void OnTriggerExit(Collider other)
    {
        grounded = false;
    }
    // public void SpawnMount()
    // {
        
    // }
}

