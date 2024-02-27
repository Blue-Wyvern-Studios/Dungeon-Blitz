using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyScript : MonoBehaviour
{
    [Header ("Variables")]
    public float awakeTime;
    private float awakeTimer = 0;
    private bool isAwake;
    public float attackCooldown;
    private float attackCooldownTimer = Mathf.Infinity;
    public float attackRange;
    public float colliderDistance;
    public float speed;
    public float health;
    public float damage;
    public float maxHealth;
    public Rigidbody2D rb2d;
    public BoxCollider2D boxCollider;
    public LayerMask playerLayer;

    [Header("References")]
    public Transform player;
    public EnemyHealthBarBehaviour HealthBar;
    private HealthManager playerHealth;

    void Start()
    {
        isAwake = false;
    }

    void Update()
    {
        //   HealthBar.SetHealth(health, maxHealth);

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (isAwake == false)
        {
            // Asleep / idle animation
        }

        // waking up if player stays close for long enough
        if (distanceFromPlayer <= 3)
        {
            if (isAwake == false)
            {
                awakeTimer += Time.deltaTime;
                if (awakeTimer > awakeTime)
                {
                    isAwake = true;
                    awakeTimer = 0;
                }
            }
        }

        attackCooldownTimer += Time.deltaTime;

        if (isAwake == true && distanceFromPlayer >= attackRange)
        {
            ChasePlayer();
        }

        if (isAwake == true && distanceFromPlayer <= attackRange)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        // Attack animation
        if(attackCooldownTimer >= attackCooldown)
        {
            attackCooldownTimer = 0;
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
            boxCollider.bounds.size, 0, Vector2.left, 0, playerLayer);

        new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<HealthManager>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * attackRange, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    void ChasePlayer()
    {
        // left of the player
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(speed, 0);
        }
        // right of the player
        else
        {
            rb2d.velocity = new Vector2(-speed, 0);
        }
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }

    void StopChasingPlayer()
    {

    }
}