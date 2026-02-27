using System.Collections;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float duration;
    public int damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void InstantiateProjectile(Vector2 direction_)
    {
        rb.linearVelocity = direction_ * speed;
        StartCoroutine(ProjectileTimer());
    }

    public IEnumerator ProjectileTimer()
    {
        yield return new WaitForSeconds(duration);
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
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
