using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHPAndAttack : MonoBehaviour
{
    public int HP;
    public int maxHP;
    public int ATK;
    public int DEF;
    public Heal heal;

    public InputAction atkAction;
    void Awake()
    {
        atkAction.Enable();

        atkAction.performed += ATKEnemy;
        atkAction.canceled -= ATKEnemy;

        heal.OnHeal += Heal;
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
    public void Heal()
    {
        HP = maxHP;
    }
}
