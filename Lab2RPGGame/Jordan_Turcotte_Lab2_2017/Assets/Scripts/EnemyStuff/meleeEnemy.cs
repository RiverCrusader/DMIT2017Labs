using UnityEngine;

public class meleeEnemy : Enemy
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
}
