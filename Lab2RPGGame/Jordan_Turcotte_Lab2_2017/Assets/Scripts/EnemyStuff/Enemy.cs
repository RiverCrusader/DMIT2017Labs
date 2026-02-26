using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AIMovement))]
public abstract class Enemy : MonoBehaviour
{
    public string enemyName;
    public int enemyID;
    
    public int HP;
    public int ATK;
    public int DEF;

    public float attackDelay;

    public CircleOverlap sightline;
    public CircleOverlap attackRange;

    public Vector2 playerPosition;

    public Vector2 patrolRange;
    private Vector2 startingPos;
    private Vector2 nextPos;
    private AIMovement aIMovement;
    private bool patroling;

    private Coroutine attackCoroutine;

    private void Awake()
    {
        sightline.OnOverlap += SetPlayerPosition;
        attackRange.OnOverlap += SetPlayerPosition;

        aIMovement = GetComponent<AIMovement>();
        aIMovement.OnArrive += Patrol;

        startingPos = transform.position;
    }

    public void SetPlayerPosition(Vector2 pos_)
    {
        playerPosition = pos_;
    }

    [ContextMenu("Patrol")]
    public void Patrol()
    {
        //should base the patrol range on the starting pos
        nextPos = new Vector2(Random.Range(startingPos.x - patrolRange.x, startingPos.x + patrolRange.x),
                                Random.Range(startingPos.y - patrolRange.y, startingPos.y + patrolRange.y));

        aIMovement.InitalizeMovement(nextPos);
    }

    public abstract void Attack();
    public void TakeDamage(int dmg_)
    {
        HP -= (dmg_ - DEF);

        if(HP <= 0)
        {
            Die();
        }
        else if(!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }

    public void Pursue()
    {
        aIMovement.InitalizeMovement(playerPosition);
    }

    private void Update()
    {
        if (attackRange.CircleOverlapCheck())
        {
            aIMovement.StopMovement();
            StartAttackCoroutine();

            return;
        }

        if (sightline.CircleOverlapCheck())
        {
            Pursue();
            

            return;
        }

        if (!patroling)
        {
            Patrol();
            patroling = true;
        }
    }

    public void StartAttackCoroutine()
    {
        if(attackCoroutine == null) attackCoroutine = StartCoroutine(AttackCoroutine());
    }
    public IEnumerator AttackCoroutine()
    {
        while (attackRange.CircleOverlapCheck())
        {
            Attack();
            yield return new WaitForSeconds(attackDelay);
        }
        attackCoroutine = null;
        //yield return null;
    }

}
