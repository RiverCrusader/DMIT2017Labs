using UnityEngine;

public class MeleeEnemy : Enemy
{
    public Transform Aim;
    public GameObject melee;
    private bool isAttacking = false;
    public float atkDuration;
    private float atkTimer;

    public override void Attack()
    {
        Vector2 direction = playerPosition - (Vector2)transform.position;
        Aim.transform.up = -direction;

        if(!isAttacking)
        {
            melee.SetActive(true);
            isAttacking = true;
        } 
    }
    protected override void Update()
    {
        base.Update();

        if(isAttacking)
        {
            CheckMeleeTimer();
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
}
