using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public Rigidbody2D bulletRB;

    public float damageAmount = 10;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

        //making bullet move towards player
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);

        //rotating bullet based on direction
        float rotation = Mathf.Atan2(-moveDir.y, -moveDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);

        DestroyProjectile(5);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //destroy projectile when hit ground
        if (collision.CompareTag("Ground"))
        {
            DestroyProjectile(0);
        }
        //damage player and destroy bullet when hit player
        else if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthManager>().healthAmount -= damageAmount;
            DestroyProjectile(0);
        }
    }

    //this function exists because of when i add bullet explode animations
    void DestroyProjectile(int timeout)
    {
        Destroy(gameObject, timeout);
    }
}
