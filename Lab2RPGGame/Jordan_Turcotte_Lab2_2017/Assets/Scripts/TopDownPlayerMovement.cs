using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayerMovement : MonoBehaviour
{
    public InputAction moveInput;
    private Vector2 moveDirection = Vector2.zero;
    public float moveSpeed;

    public event Action<Vector2> OnMove;

    //attacking
    public event Action OnTakeDamage;
    public int HP;
    public int maxHP;
    public int ATK;
    public int DEF;
    public Heal heal;

    public InputAction atkAction;

    public Transform Aim;
    public bool isWalking = false;
    //melee
    public GameObject melee;
    private bool isAttacking = false;
    public float atkDuration;
    private float atkTimer;
    
    void Awake()
    {
        moveInput.Enable();

        moveInput.performed += GetMoveVector;
        moveInput.canceled += GetMoveVector;

        //attacking
        atkAction.Enable();

        atkAction.performed += ATKEnemy;
        atkAction.canceled -= ATKEnemy;

        // heal = GameObject.FindGameObjectWithTag("Heal").GetComponent<Heal>();
        if(heal != null) heal.OnHeal += Heal;

        HP = maxHP;
    }

    public void GetMoveVector(InputAction.CallbackContext c)
    {
        moveDirection = c.ReadValue<Vector2>();

        if(moveDirection.x != 0 || moveDirection.y != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        OnMove?.Invoke(moveDirection);
    }

    void Update()
    {
        
        transform.position += new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed * Time.deltaTime;

        if(isWalking)
        {
            Vector3 atkDirection = Vector3.left * moveDirection.x + Vector3.down * moveDirection.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, atkDirection);
        }

        if(isAttacking)
        {
            CheckMeleeTimer();
        }
    }

    
    public void ATKEnemy(InputAction.CallbackContext c)
    {
        Stab();
    }

    private void Stab()
    {
        if(!isAttacking)
        {
            melee.SetActive(true);
            isAttacking = true;
        }
    }

    private void CheckMeleeTimer()
    {
        atkTimer += Time.deltaTime;
        if(atkTimer >= atkDuration)
        {
            atkTimer = 0;
            isAttacking = false;
            melee.SetActive(false);
        }
    }

    public void TakeDamage(int dmg_)
    {
        HP -= (dmg_ - DEF);
        OnTakeDamage?.Invoke();
    }
    public void Heal()
    {
        HP = maxHP;
        OnTakeDamage?.Invoke();
    }
}
