using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersProjectileScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;

    private Rigidbody2D rb;
    public float force;
    public float playerDamage;

    void Start()
    {
        //getting the bullet direction and rotation

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //giving damage to enemy when coliding with it
        var enemy = collision.collider.GetComponent<FlyingEnemyScript>();
        if(enemy)
        {
            enemy.TakeHit(playerDamage);
        }
        //if the bullet collides with anything other than one way platforms then it gets destroyed
        if(!(collision.collider.tag == "OneWayPlatform"))
        {
            Destroy(gameObject);
        }
        
    }
}
