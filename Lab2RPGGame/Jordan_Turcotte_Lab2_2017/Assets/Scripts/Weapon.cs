using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int damage;

    void Awake()
    {
        damage = GetComponentInParent<TopDownPlayerMovement>().ATK;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
