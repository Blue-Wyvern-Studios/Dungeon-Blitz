using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public GameObject destination;
    private GameObject player;
  bool init = false;
  bool overit = false;
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
    //check if player near teleport
    //unclicable teleport just go near it
    if (collision.tag == "Player")
    {
      init = true;
      if (type == 0)
      {
        if (init == true)
        {
          player.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, -5);
        }
      }
    }
  }
  private void OnMouseOver()
  {//check if mouse over teleport
   //clickabl teleport get near and click on it or press E
    overit = true;
    if (type == 1 || type == 3)
    {
      if ((init && overit && Input.GetMouseButtonDown(0)) || (init && Input.GetKeyDown(KeyCode.E)))
      {
        if (type == 1)
        {
          player.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, -5);
        }
        else if (type == 3)
        {
          SceneManager.LoadScene("...");
        }
      }
    }

  }
}
