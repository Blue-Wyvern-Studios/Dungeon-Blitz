using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public GameObject destination;
    private GameObject player;
  bool init = false;
  bool overit = false;
  public int type; //type of teleport (0:non-clicable, 1:clicable inside dungeon, 2: clicable scene loader)
  public int worldid;//store the id of the dungeons
  public int dungonid;//store th id of th wotld
  public string scene;//witch scene to load
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
          GameObject.Find("dungeonsetter").GetComponent<classesandload>().ch.dungeonid = dungonid;
          GameObject.Find("dungeonsetter").GetComponent<classesandload>().ch.worldid = worldid;
          GameObject.Find("dungeonsetter").GetComponent<classesandload>().ch.position = GameObject.Find("Player").transform.position;
          GameObject.Find("dungeonsetter").GetComponent<classesandload>().localsave();
          SceneManager.LoadScene(scene);
        }
      }
    }

  }
}
