using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using Unity.VisualScripting;
using System.Linq;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEditor.SearchService;

public class classesandload : MonoBehaviour
{
  //id for dungeons: lostatsea:0, goblinkidnappers:1, goblincamp:2, nephit'squest:3, dragon's dream:4
  //id for worlds: wolf's end:0

  #region maps
  public GameObject[] dungons;
  public GameObject[] worlds;
  #endregion
  #region
  public characters [] charactersmain=new characters[8];
  public int selectedch=0;
  #endregion

  public class characters
  {
    public string name,chclass;
    public int[] mainstats1 = new int[4];//health,attack,xpertise,defence
    public int[]resistantcs= new int[6];//firedef,aitdef,earthdef,lifedef,deaethdef,icedef
    public int[]bonusdmg=new int[6];//firdmg,airdmg,earthdmg,lifedmg,deathdmg,icedmg
    public int[] findings = new int[4];//gear,met,gold,xp
    public double[] mainstats2=new double[6];//attackspeed,critch,critdmg,movementspeed,recovery,tenacity
    public int[] others = new int[4];//dungeonid,worldid,level,chid
    public Vector3 position=new Vector3(0,0,-5);
    public npc[] npcs;

    public characters(int id, string[] data)
    {
      int step = 0;
      bool found = false;
      this.others[3] = id;
      while (step != data.Length&&!found)
      {
        if (data[step] == "Character:" + id)
        {
          string[] datas = data[step + 1].Split(';');
          for (int j = 0; j < mainstats1.Length; j++)
          {
            mainstats1[j] = int.Parse(datas[j]);
          }
          datas = data[step + 2].Split(';');
          for (int j = 0; j < mainstats2.Length; j++)
          {
            mainstats2[j] = int.Parse(datas[j]);
          }
          datas = data[step + 3].Split(";");
          for (int j = 0; j < others.Length; j++)
          {
            others[j] = int.Parse(datas[j]);
          }
          datas = data[step + 4].Split(";");
          name = datas[0];
          chclass = datas[1];
          position = new Vector3(float.Parse(datas[2].Split(',')[0]), float.Parse(datas[2].Split(',')[1]),-5f);
        npscgiver();
          for (int j = 5; j < npcs.Length; j++)
          {
            datas = data[step + j].Split(";");
            npcs[j - 4] = new npc(datas[0], int.Parse(datas[1]), bool.Parse(datas[2]));
          }
          found = true;
        }
        step++;
      }
      if (!found)
      {
        name = "Name "+id;
        others[2] = 1;
        chclass = "";
        npscgiver();
        position = new Vector3(0, 0, -5);
      }
    }
    public characters(int id)
    {
      name = "Name " + id;
      others[2] = 1;
      chclass = "";
      position = new Vector3(0, 0, -5);
      npscgiver();
    }
    public characters(int id ,string chclass)
    {
      others[2] = 1;
      npscgiver();
      if (chclass == "Paladin")
      {
        name = "Name "+id;
        others[0] = 0;
        others[1] = 0;
        others[2] = 1;
        others[3] = id;
        this.chclass = chclass;
        mainstats1[0] = 100;
        mainstats1[1] = 10;
        mainstats1[2] = 5;
        mainstats1[3] = 15;
        mainstats2[0] = 100;
        mainstats2[1] = 10;
        mainstats2[2] = 20;
        mainstats2[3] = 6;
        mainstats2[4] = 10;
      }
    }
    public void save(StreamWriter wr)
    {
      wr.WriteLine("Character:" + others[3]);
      string outline = "";
      for (int i = 0; i < mainstats1.Length; i++)
      {
        if (i != mainstats1.Length - 1) { outline += mainstats1[i] + ";"; }
        else {outline+=mainstats1[i]; }
      }
      wr.WriteLine(outline);
      outline = "";
      outline = "";
      for (int i = 0; i < mainstats2.Length; i++)
      {
        if (i != mainstats2.Length - 1) { outline += mainstats2[i] + ";"; }
        else { outline += mainstats2[i]; }
      }
      wr.WriteLine(outline);
      outline = "";
      for (int i = 0; i < others.Length; i++)
      {
        if (i != others.Length - 1) { outline += others[i] + ";"; }
        else { outline += others[i]; }
      }
      wr.WriteLine(outline);
      outline = name + ";" + chclass+";"+position.x+","+position.y+","+"-5";
      wr.WriteLine(outline);
      for (int i = 0; i < npcs.Length; i++)
      {
        wr.WriteLine(npcs[i].save());
      }
    }
    public void mainmenusetter()
    {
      if (chclass != "")
      {
        GameObject.Find("Selected Char Name Txt").GetComponent<TextMeshProUGUI>().text = name;
        GameObject.Find("Selected Char Level Txt").GetComponent<TextMeshProUGUI>().text = "Level: "+others[2].ToString();
        GameObject.Find("Selected Char Class Txt").GetComponent<TextMeshProUGUI>().text = chclass;

        if (chclass == "Paladin")
        {
          GameObject.Find("characterapp").GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255, 255);
          GameObject.Find("characterapp").GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Sprites/PaladinAnimationsSprites/Run and idle/idle-1");
        }
      }
      else
      {
        GameObject.Find("Selected Char Name Txt").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("Selected Char Level Txt").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("Selected Char Class Txt").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("characterapp").GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0);
      }
    }
    public void characterselectstter(GameObject set)
    {
        set.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = name;
        set.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = others[2].ToString("D2");
      if (chclass != "")
      {
        if (chclass == "Paladin")
        {
          set.transform.GetChild(3).GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("UI/Main Menu/paladinemblem");
          set.transform.GetChild(3).GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255, 255);
        }
      }
      else
      {
        set.transform.GetChild(3).GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0);
      }
    }
    void npscgiver()
    {
      npcs = new npc[1];
      npcs[0] = new npc("Captain", 0, false);
    }
  }



  public class npc
  {
    string name;
    public int queststep;
    int dialogstep = 0;
    public bool completed = false;
    List<string>[] dialoges;
    public npc(string name,int queststep,bool complet)
    {
      this.Name = name;
      if (name == "Captain")
      {
        dialoges = new List<string>[2];
        for (int i = 0; i < dialoges.Length; i++)
        {
          dialoges[i] = new List<string>();
        }
        this.queststep = queststep;
        dialoges[0].Add("Captain:Hi!");
        dialoges[0].Add("Player:Hi!");
        dialoges[0].Add("Captain:Hi!!!!");
        dialoges[1].Add("Captain:Hi!!!");
        dialoges[1].Add("Captain:Hi!!");
        dialoges[1].Add("Captain:Hi!");
        this.completed = complet;
      }
    }
    public void interact()
    {
      Transform change = GameObject.Find(dialoges[queststep][dialogstep].Split(':')[0]).transform.GetChild(0).GetChild(0);
      change.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialoges[queststep][dialogstep].Split(':')[1];
      if (dialogstep + 1 == dialoges[queststep].Count)
      {
        queststep++;
        dialogstep = 0;
      }
      else
      {
        dialogstep++;
      }
    }
    public string save()
    {
      return name+";"+queststep+";"+completed;
    }
    public void nextquest() => queststep++;
    public string Name { get => name; set => name = value; }
  }


  // Start is called before the first frame update
  private void Awake()
  {
  }
  void Start()
  {
    StartCoroutine(startvoid());
  }
    // Update is called once per frame
    void Update()
  {

  }
  private void OnApplicationQuit()
  {
    if (SceneManager.GetActiveScene().name != "Main Menu")
    {
      if (SceneManager.GetActiveScene().name == "worlds")
      {
        charactersmain[selectedch].position = GameObject.Find("Player").transform.position;
      }
      localsave();
    }
  }
  public void localsave()
  {
    StreamWriter wr = new StreamWriter(Path.Combine(Application.dataPath, "game.txt"));
    for (int i = 0; i < charactersmain.Length; i++)
    {
      charactersmain[i].save(wr);
    }
    wr.WriteLine("seletdch:"+selectedch);
    wr.Close();
  }


  private IEnumerator startvoid()
  {
    //load ac
    string filePath = System.IO.Path.Combine(Application.dataPath, "DB_AC_Loader.exe");
    if (System.IO.File.Exists(filePath))
    {
      Process.Start(filePath);
    }
    else
    {
      UnityEngine.Debug.LogError("DB_AC_Loader.exe not found in the game directory.");
    }

    yield return new WaitForSeconds(0.5f);
    //load saved data

    string[] data=new string[0];
    try
    {
      data = File.ReadAllLines(Path.Combine(Application.dataPath, "game.txt"));
      if (data.Length > 1)
      {
        selectedch = int.Parse(data[data.Length - 1].Split(':')[1]);
      }
    }
    catch
    {
      StreamWriter wr = new StreamWriter(Path.Combine(Application.dataPath, "game.txt"));
      wr.WriteLine("");
      wr.Close();
      data = File.ReadAllLines(Path.Combine(Application.dataPath, "game.txt"));
    }
    for (int i = 0; i < charactersmain.Length; i++)
    {
      charactersmain[i] = new characters(i,data);
    }
    if (SceneManager.GetActiveScene().name == "dungeons")
    {
      GameObject.Instantiate(dungons[charactersmain[selectedch].others[0]]);
      GameObject startpoint = GameObject.Find("starterpoint");
      GameObject.Find("Player").transform.position = new Vector3(startpoint.transform.position.x, startpoint.transform.position.y, -5);
    }
    else if (SceneManager.GetActiveScene().name == "worlds")
    {
      GameObject.Instantiate(worlds[charactersmain[selectedch].others[1]]);
      GameObject.Find("Player").transform.position = charactersmain[selectedch].position;
    }
  }
  private IEnumerator talkwindow()
  {
    yield return new WaitForSeconds(0.5f);
  }

}
