using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class objects : MonoBehaviour
{

  #region varaibles
  //tipboards
  float steptip = -1;
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
    if (transform.name.Contains("tip"))
    {
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
    if (transform.name.Contains("tip"))
    {
      transform.GetComponent <objects>().steptip = 0.05f;
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
    if (transform.name.Contains("tip"))
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
  }
}
