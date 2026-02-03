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
        projectile.InstantiateProjectile(new Vector2(playerPosition.x, -playerPosition.y).normalized);
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Patrol()
    {
        throw new System.NotImplementedException();
    }

    public override void Pursue()
    {
    }

    public override void TakeDamage(float dmg_)
    {
        throw new System.NotImplementedException();
    }

   
}
