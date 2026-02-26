using UnityEngine;

public class meleeEnemy : Enemy
{
    public Transform Aim;
    public GameObject melee;
    private bool isAttacking = false;
    public float atkDuration;
    private float atkTimer;
    
    public override void Attack()
    {
        
    }
}
