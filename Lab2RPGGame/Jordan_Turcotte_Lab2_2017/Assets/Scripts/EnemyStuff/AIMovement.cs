using System;
using System.Collections;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float range;
    public float moveSpeed;
    private Rigidbody2D rb;
    public event Action OnArrive;
    private Vector3 newPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InitalizeMovement(Vector3 newPosition_)
    {
        newPosition = newPosition_;
        StartCoroutine(MoveToPosition());
    }
    public void SetNewPosition(Vector3 newPosition_) { newPosition = newPosition_; }

    public void StopMovement()
    {
        StopAllCoroutines();
        rb.linearVelocity = Vector3.zero;
    }
    private IEnumerator MoveToPosition()
    {
        bool inRange = false;

        while(!inRange)
        {
            Vector2 moveDirection = newPosition - transform.position;
            moveDirection.Normalize();

            rb.linearVelocity = moveDirection * moveSpeed;

            inRange = Vector2.Distance(transform.position, newPosition) < range;

            if(inRange)
            {
                rb.linearVelocity = Vector3.zero;
            }
            yield return null; 
        }
        OnArrive?.Invoke();

        yield return null;
    }
}
