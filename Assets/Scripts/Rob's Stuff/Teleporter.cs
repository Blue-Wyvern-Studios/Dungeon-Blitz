using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public GameObject destination;
    private GameObject player;
  public int type; //type of teleport (0:non-clicable, 1:clicable inside dungeon, 2: clicable scene loader)
  public int scenes;//locally save dungon id and during loading it'll read out from local and place the gameobject(not yet possible)
  //how to use: if you wanna place a teleporter attach the component and give it the informations (type, destination(other tleporter) and scen if needed thn enjoy)
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tp player to desired location (keeping the z to -5 which is the original z pos of the player)
        if (collision.tag == "Player"&& type==0)
        {
            player.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, -5);
        }
    }
  private void OnMouseOver()
  {//check if it's a clicable if yes then based on type it's teleport to the other teleport or load save dungeonid
    if (type == 1||type==3)
    {
      if (Input.GetMouseButtonDown(0)&&type==1)
      {
        if (type == 1)
        { 
        GameObject.Find("Player").transform.position = destination.transform.position;
        }
        else if(type==3)
        {
          SceneManager.LoadScene("...");
        }
      }
    }
  }
}
