using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyScript : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float fireRate;
    private float nextFireTime;
    public float lineOfSite;
    public float shootingRange;
    public float hitpoints;
    public float maxHitpoints;

    [Header("References")]
    public GameObject projectile;
    private Transform player;
    public EnemyHealthBarBehaviour HealthBar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hitpoints = maxHitpoints;
        HealthBar.SetHealth(hitpoints, maxHitpoints);
    }

    private void Update()
    {
        HealthBar.SetHealth(hitpoints, maxHitpoints);

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        //get close to player
        if (distanceFromPlayer <= lineOfSite && distanceFromPlayer > shootingRange)
        {
            Vector3 moveTowards = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.position = new Vector3(moveTowards.x, moveTowards.y, transform.position.z);
        }
        //shoot player if close enough
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

    }
    //taking damage from player
    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        HealthBar.SetHealth(hitpoints, maxHitpoints);

        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
