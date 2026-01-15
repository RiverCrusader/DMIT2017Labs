using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsMovement : MonoBehaviour
{
    //add another type of obstacles reduce speed for duration of time
    //build map
    //add deceloration
    
    public InputAction acceloration;
    public InputAction brake;
    public InputAction steering;

    private Rigidbody rb;


    public float accelorationValue;
    public float brakeValue;
    public float steervalue;

    public float decelerationValue = 4.0f;


    public float currentSpeed;
    public float maxSpeed;

    const float ACCELORATION_FACTOR = 20.0f;
    const float BRAKE_FACTOR = 20.0f;
    const float STEER_FACTOR = 20.0f;




    void Start()
    {
        rb = GetComponent<Rigidbody>();

        acceloration.Enable();
        brake.Enable();
        steering.Enable();


        acceloration.performed += AccelorationInput;
        acceloration.canceled += AccelorationInput;

        brake.performed += BrakeInput;
        brake.canceled += BrakeInput;

        steering.performed += SteeringInput;
        steering.canceled += SteeringInput;
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
        steervalue = c.ReadValue<float>() * STEER_FACTOR;
    }

    void Update()
    {

        currentSpeed -= decelerationValue * Time.deltaTime;
        currentSpeed += accelorationValue * Time.deltaTime;
        currentSpeed -= brakeValue * Time.deltaTime;
        
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        if(Mathf.Abs(currentSpeed) > 0.0f)
        {
            float steer = steervalue * Mathf.Sign(currentSpeed);

            transform.Rotate(0f, steer * Time.deltaTime ,0f);
        }

        //tmp = temporary  ( for naming conventions) 
        Vector3 tmp = transform.forward * currentSpeed;
        //this will overwright gravity calcs so need to reset them so they work


        //rb.AddForce(tmp, ForceMode.Force);

        
        rb.linearVelocity = tmp;

    }

    public void SpeedBoost(float boost)
    {
        StartCoroutine(BoostTimer(boost, 5.0f));
    }

    private IEnumerator BoostTimer(float boost_, float duraction_)
    {
        currentSpeed += boost_;
        maxSpeed += boost_ * 2;

        yield return new WaitForSeconds(duraction_);

        currentSpeed -= boost_;
        maxSpeed -= boost_ * 2;
    }

}

