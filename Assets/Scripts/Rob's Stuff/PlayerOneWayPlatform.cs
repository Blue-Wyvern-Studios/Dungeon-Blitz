using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    public GameObject currentOneWayPlatform;
  //how to use: add script to platform object (if want to be two way platform add another collider with trigger enabled)
    private void Update()
    {
        //calling the disableCollision funcion if on a platform and if pressing S
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
                StartCoroutine(DisableCollision());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag=="Player")
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }
  private void OnTriggerStay2D(Collider2D collision)
  {
    if (collision.tag=="Player")
    {
      StartCoroutine(DisableCollision());
    }
  }
  private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag=="Player")
        {
            currentOneWayPlatform = null;
        }
    }

    //disabling collision between player and platform
    private IEnumerator DisableCollision()
    {
    if (currentOneWayPlatform != null)
    { 
      Collider2D platformCollider = transform.GetComponent<Collider2D>();
      Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<BoxCollider2D>(), platformCollider);
      yield return new WaitForSeconds(0.25f);
      Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<BoxCollider2D>(), platformCollider, false);
    }
    }
}