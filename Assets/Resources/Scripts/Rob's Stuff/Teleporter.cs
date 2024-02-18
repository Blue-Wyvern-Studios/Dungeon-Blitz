using Unity.VisualScripting;
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
  public void OnMouseOver()
  {//check if mouse over teleport
   //clickabl teleport get near and click on it or press E
    overit = true;
    if (type == 1 ||type==3)
    {
      if ((init && overit && Input.GetMouseButtonDown(0)) || (init && Input.GetKeyDown(KeyCode.E))|| ( transform.name.Contains("Enter")))
      {
        if (type == 1)
        {
          player.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, -5);
        }
        else if (transform.GetComponent<Teleporter>().type == 3)
        {
          if (GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].mainstats1[0] != 0)
          {
            if (SceneManager.GetActiveScene().name == "worlds")
            {
              GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].position = GameObject.Find("Player").transform.position;
            }
            GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].others[0] = dungonid;
            GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].others[1] = worldid;
            GameObject.Find("dungeonsetter").GetComponent<classesandload>().localsave();
            if (transform.name.Contains("Enter"))
            {
              if (GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].position == new Vector3(0, 0, -5))
              {
                SceneManager.LoadScene("dungeons");
              }
              else
              {
                SceneManager.LoadScene("worlds");
              }
            }
            else
            { 
              SceneManager.LoadScene(scene);
            }
          }
        }
      }
    }
  }

  public void test()
  {
    GameObject.Find("dungeonsetter").GetComponent<classesandload>().localsave();
  }
}
