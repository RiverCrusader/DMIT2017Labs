using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayerMovement : MonoBehaviour
{
    public InputAction moveInput;
    private Vector2 moveDirection = Vector2.zero;
    public float moveSpeed;

    public event Action<Vector2> OnMove;

    void Awake()
    {
        moveInput.Enable();

        moveInput.performed += GetMoveVector;
        moveInput.canceled += GetMoveVector;


    }

    public void GetMoveVector(InputAction.CallbackContext c)
    {
        moveDirection = c.ReadValue<Vector2>();
        OnMove?.Invoke(moveDirection);
    }

    void Update()
    {
        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed *Time.deltaTime;
    }
}
