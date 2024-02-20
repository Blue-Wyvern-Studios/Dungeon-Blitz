using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenuManager : MonoBehaviour
{

  private void Update()
  {
    if (transform.name.Contains("Character"))
    {
      int step0 = 0;
      bool found = false;
      try
      {
        while (step0 != transform.parent.childCount && !found)
        {
          if (transform == transform.parent.GetChild(step0))
          {
            GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].mainmenusetter();
            GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[step0].characterselectstter(transform.gameObject);
            found = true;
          }
          step0++;
        }
      }
      catch { }
    }
  }
  public void selectch()
  {
    for (int i = 0; i < transform.parent.childCount; i++)
    {
      if (transform == transform.parent.GetChild(i))
      {
        GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch = i;
      }
    }
  }
  public void characterselect()
  {
    if (transform.name != "okay")
    {
      GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch] = new classesandload.characters(GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch, transform.name);
    }
    else
    {
      if (GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].mainstats1[0] !=0 )
      { 
      GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch].name = transform.parent.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text;
      }
    }
  }

  public void dletebuttondis()
  {
    for (int i = 0; i < transform.parent.childCount; i++)
    {
      if (transform == transform.parent.GetChild(i))
      {
      
        transform.GetChild(2).gameObject.SetActive(true);
      }
      else
      {
        transform.parent.GetChild(i).GetChild(2).gameObject.SetActive(false);
      }
    }
  
  }
  public void deletech()
  {
    GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch] = new classesandload.characters(GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch);
  }
}
