using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHPAndAttack : MonoBehaviour
{
    public int HP;
    public int ATK;
    public int DEF;

    public InputAction atkAction;
    void Awake()
    {
        atkAction.Enable();

        atkAction.performed += ATKEnemy;
        atkAction.canceled -= ATKEnemy;
    }

    public void ATKEnemy(InputAction.CallbackContext c)
    {
        Stab();
    }

    private void Stab()
    {
        
    }

    public void TakeDamage(int dmg_)
    {
        HP -= (dmg_ - DEF);
    }
}
