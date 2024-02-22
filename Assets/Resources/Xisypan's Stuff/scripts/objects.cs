using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Diagnostics;
using Cinemachine;

public class objects : MonoBehaviour
{

  #region varaibles
  //tipboards
  float steptip = -1;
  //lighning
  double lightningtimer=5;
  #endregion
  // Start is called before the first frame update
  void Start()
  {
    //spiktrap
    if (transform.name == "spiketrapwhole")
    {
      for (int i = 0; i < transform.childCount; i++)
      {

        transform.GetChild(i).GetComponent<Animator>().speed = 0;
      }
      for (int i = 0; i < transform.childCount; i++)
      {
        transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
      }
    }
    else if (transform.name.Contains("tip"))
    {
      transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }
    else if (transform.name == "boat")
    {
      transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
    }
    else if (transform.name == "frontcloud")
    {
      transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
    }
    else if (transform.name == "lightning")
    {
      transform.GetComponent<Animator>().speed = 0;
      transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }
  }
  // Update is called once per frame
  void Update()
  {
    if (transform.name.Contains("tip"))
    {
      if (transform.GetComponent<SpriteRenderer>().color.a + steptip >= 0 && transform.GetComponent<SpriteRenderer>().color.a + steptip <= 255)
      {
        transform.GetComponent<SpriteRenderer>().color = new Color(transform.GetComponent<SpriteRenderer>().color.r + steptip, transform.GetComponent<SpriteRenderer>().color.g + steptip, transform.GetComponent<SpriteRenderer>().color.b + steptip, transform.GetComponent<SpriteRenderer>().color.a + steptip);
      }
    }
    else if (transform.name == "lightning")
    {
      if (lightningtimer < 0)
      {

        int number = UnityEngine.Random.Range(0, 100);
        if (number >= 0 && number <= 5)
        {
          transform.GetComponent<Animator>().speed = 1;
          lightningtimer = 5;
          transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }

      }
      else
      {
        lightningtimer -= Time.deltaTime;
      }
    }
    else if (transform.name == "bg")
    {
      transform.position = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y,2);
    }
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (transform.name == "spiketrapwhole")
    {
      if (collision.tag == "Player")
      {
        StartCoroutine(wait());
      }
    }
    else if (transform.name.Contains("tip"))
    {
      transform.GetComponent<objects>().steptip = 0.05f;
    }
    else if (transform.name == "boat")
    {
      if (collision.name == "up")
      {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.1f);
      }
      else if (collision.name == "down")
      {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.1f);
      }
    }
    else if (transform.name == "frontcloud")
    {
      if (collision.name == "left")
      { 
      transform.position=new Vector3 (GameObject.Find("right").transform.position.x, GameObject.Find("right").transform.position.y, transform.position.z);
      }
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (transform.name.Contains("tip"))
    {
      transform.GetComponent<objects>().steptip = -0.05f;
    }

  }
  private IEnumerator wait()
  {
    if (transform.name == "spiketrapwhole")
    {
      for (int i = 0; i < transform.childCount; i++)
      {
        transform.GetChild(i).GetComponent<Animator>().speed = 1;
      }
      yield return new WaitForSeconds(0.5f);

      for (int i = 0; i < transform.childCount; i++)
      {
        transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
      }
    }
    else if (transform.name.Contains("tip"))
    {
      if (transform.GetComponent<SpriteRenderer>().color.a-1!>=0 && transform.GetComponent<SpriteRenderer>().color.a + 1 <= 255)
      { 
        transform.GetComponent<SpriteRenderer>().color = new Color(transform.GetComponent<SpriteRenderer>().color.r + steptip, transform.GetComponent<SpriteRenderer>().color.g + steptip, transform.GetComponent<SpriteRenderer>().color.b + steptip, transform.GetComponent<SpriteRenderer>().color.a + steptip);
      }
    }
  }
  public void stopanim()
  {
    transform.GetComponent<Animator>().speed = 0;
    if (transform.name == "lightning")
    {
      transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }
  }
  private void OnMouseEnter()
  {
    
    if (transform.name.Contains("camerapoint"))
    {
      transform.parent.GetChild(0).GetComponent<CinemachineVirtualCamera>().Follow = transform;
    }
  }

}
