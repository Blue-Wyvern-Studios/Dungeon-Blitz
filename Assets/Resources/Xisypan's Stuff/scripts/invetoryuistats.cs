using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class invetoryuistats : MonoBehaviour
{
  bool isopen = false;
  classesandload.characters playerinv;
  // Start is called before the first frame update
    void Start()
    {
    playerinv = GameObject.Find("dungeonsetter").GetComponent<classesandload>().charactersmain[GameObject.Find("dungeonsetter").GetComponent<classesandload>().selectedch];
    }

  // Update is called once per frame
  void Update()
  {
    if (transform.name == "Inventory")
    {
      transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerinv.name;
    }
    else if (transform.name == "States")
    {
      transform.GetChild(transform.childCount - 1).GetComponent<TextMeshProUGUI>().text = playerinv.chclass;
      transform.GetChild(transform.childCount - 2).GetComponent<TextMeshProUGUI>().text = playerinv.name;
      int step1 = 0;
      int step2 = 0;
      while (step2 != playerinv.mainstats1.Length)
      {
        transform.GetChild(step1).GetComponent<TextMeshProUGUI>().text = playerinv.mainstats1[step2].ToString();
        step2++;
        step1++;
      }
      step2 = 0;
      while (step2 != playerinv.mainstats2.Length)
      {
        transform.GetChild(step1).GetComponent<TextMeshProUGUI>().text = playerinv.mainstats2[step2].ToString()+"%";
        step2++;
        step1++;
      }
    }
    else if (transform.name == "States2")
    {
      int step1 = 1;
      int step2 = 0;
      while (step2 != playerinv.findings.Length)
      {
        transform.GetChild(step1).GetComponent<TextMeshProUGUI>().text = playerinv.findings[step2].ToString() + "%";
        step2++;
        step1++;
      }
      step2 = 0;
      while (step2 != playerinv.bonusdmg.Length)
      {
        transform.GetChild(step1).GetComponent<TextMeshProUGUI>().text = playerinv.bonusdmg[step2].ToString() + "%";
        step2++;
        step1++;
      }
      step2 = 0;
      while (step2 != playerinv.resistantcs.Length)
      {
        transform.GetChild(step1).GetComponent<TextMeshProUGUI>().text = playerinv.resistantcs[step2].ToString() + "%";
        step2++;
        step1++;
      }
    }


    else if (transform.name == "CanvasInventory")
    {
      if (Input.GetKeyDown(KeyCode.I))
      {
        invopenclose();
      }
    }
  }
  public void invopenclose()
  {
    if (isopen)
    {
      for (int i = 0; i < transform.childCount; i++)
      {
        transform.GetChild(i).gameObject.SetActive(false);
      }
      isopen = false;
    }
    else
    {
      for (int i = 0; i < transform.childCount; i++)
      {
        transform.GetChild(i).gameObject.SetActive(true);
      }
      isopen = true;
    }
  }
}
