using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class npcs : MonoBehaviour
{



  classesandload.npc currentnpc;
  // Start is called before the first frame update
  void Start()
  {
    for (int i = 0; i < GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].npcs.Length; i++)
    {
      if (transform.name==GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].npcs[i].Name)
      { 
       currentnpc = GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].npcs[i];
      }
    }
  }
  private void OnMouseEnter()
  {
    GameObject.Find("Cursor Manager").GetComponent<CursorManager>().dialogbool = true;
  }
  private void OnMouseExit()
  {
    GameObject.Find("Cursor Manager").GetComponent<CursorManager>().dialogbool = false;
  }
  public void dialog()
  {
    currentnpc.interact();
  }
}
  

