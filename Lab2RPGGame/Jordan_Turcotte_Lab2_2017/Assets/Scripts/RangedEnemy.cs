using Unity.VisualScripting;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnLocation;
    public override void Attack()
    {
        // instantiate a projectile
        // give the projectile a direction + velocity
        // projectile handles collisions 

        GameObject obj = Instantiate(projectilePrefab, projectileSpawnLocation.position, Quaternion.identity);
        SimpleProjectile projectile = obj.GetComponent<SimpleProjectile>();

        float directionX = playerPosition.x - transform.position.x;
        float directionY = playerPosition.y - transform.position.y;

        projectile.InstantiateProjectile(new Vector2(directionX, directionY).normalized);
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    // public override void Patrol()
    // {
    //     throw new System.NotImplementedException();
    // }

    // public override void Pursue()
    // {
        
    // }

    public override void TakeDamage(float dmg_)
    {
        throw new System.NotImplementedException();
    }

   
}
