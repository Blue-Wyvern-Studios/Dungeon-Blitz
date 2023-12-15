using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject destination;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tp player to desired location (keeping the z to -5 which is the original z pos of the player)
        if (collision.tag == "Player")
        {
            player.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, -5);
        }
    }
}
