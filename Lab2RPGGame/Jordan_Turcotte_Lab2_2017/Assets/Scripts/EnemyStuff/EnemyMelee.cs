using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    private int damage;

    void Awake()
    {
        damage = GetComponentInParent<TopDownPlayerMovement>().ATK;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        TopDownPlayerMovement player = collision.GetComponent<TopDownPlayerMovement>();

        if(player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
