using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class classesandload : MonoBehaviour
{
  //id for dungeons: lostatsea:0, goblinkidnappers:1, goblincamp:2, nephit'squest:3, dragon's dream:4
  //id for worlds: wolf's end:0

  #region maps
  public GameObject[] dungons;
  public GameObject[] worlds;
  #endregion

  public class characters
  {
    string name;
    public int health, attack, expertise, defense, attacksped, gearfinding, metafinding, goldfinding, expbonus, dmgfire, dmgice, dmgearth, dmgdeath, dmglife, dmgair, deffire, defice, defearth, dfdeath, deflife, defair, level;
    public double critchance, critpower, recovery, movementspeed, tenacity;
    public int dungeonid, worldid;
    public Vector3 position;

    public characters(string name, int health, int attack, int expertise, int defense, int attacksped, int gearfinding, int metafinding, int goldfinding, int expbonus, int dmgfire, int dmgice, int dmgearth, int dmgdeath, int dmglife, int dmgair, int deffire, int defice, int defearth, int dfdeath, int deflife, int defair, int level, double critchance, double critpower, double recovery, double movementspeed, double tenacity, int dungeonid, int worldid)
    {
      this.name = name;
      this.health = health;
      this.attack = attack;
      this.expertise = expertise;
      this.defense = defense;
      this.attacksped = attacksped;
      this.gearfinding = gearfinding;
      this.metafinding = metafinding;
      this.goldfinding = goldfinding;
      this.expbonus = expbonus;
      this.dmgfire = dmgfire;
      this.dmgice = dmgice;
      this.dmgearth = dmgearth;
      this.dmgdeath = dmgdeath;
      this.dmglife = dmglife;
      this.dmgair = dmgair;
      this.deffire = deffire;
      this.defice = defice;
      this.defearth = defearth;
      this.dfdeath = dfdeath;
      this.deflife = deflife;
      this.defair = defair;
      this.level = level;
      this.critchance = critchance;
      this.critpower = critpower;
      this.recovery = recovery;
      this.movementspeed = movementspeed;
      this.tenacity = tenacity;
      this.dungeonid = dungeonid;
      this.worldid = worldid;
    }
    public characters(string data)
    {
      string[]datas=data.Split(';');
      this.dungeonid = int.Parse(datas[0]);
      this.worldid = int.Parse(datas[1]);
      this.position = new Vector3(float.Parse(datas[2].Split(',')[0]), float.Parse(datas[2].Split(',')[1]), float.Parse(datas[2].Split(',')[2]));
    }
    public characters()
    {
      dungeonid = 0;
      worldid = 0;
      position = new Vector3(0, 0, -5);
    }
    public string save()
    {
      return dungeonid + ";" + worldid+";"+position.x+","+position.y+","+position.z;
    }
  }


  public characters ch;
  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(startvoid());
  }
    // Update is called once per frame
    void Update()
  {
  }

  public void localsave()
  {
    StreamWriter wr = new StreamWriter(Path.Combine(Application.dataPath, "ch.txt"));
    wr.WriteLine(ch.save());
    wr.Close();
  }
  public string loadlocal()
  {
    string filePath = System.IO.Path.Combine(Application.dataPath, "DB_AC_Loader.exe");

    if (System.IO.File.Exists(filePath))
    {
      Process.Start(filePath);
    }
    else
    {
      UnityEngine.Debug.LogError("DB_AC_Loader.exe not found in the game directory.");
    }
    StreamReader sr = new StreamReader(Path.Combine(Application.dataPath, "ch.txt"));
    return sr.ReadLine();
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
    if (SceneManager.GetActiveScene().name == "dungeons")
    {
      ch = new characters(loadlocal());
      GameObject.Instantiate(dungons[ch.dungeonid]);
      GameObject startpoint = GameObject.Find("starterpoint");
      GameObject.Find("Player").transform.position = new Vector3(startpoint.transform.position.x, startpoint.transform.position.y, -5);
    }
    else if (SceneManager.GetActiveScene().name == "worlds")
    {
      ch = new characters(loadlocal());
      GameObject.Instantiate(worlds[ch.worldid]);
      GameObject.Find("Player").transform.position = ch.position;
    }
    else if (SceneManager.GetActiveScene().name == "Xisypan's Scene")
    {
      SceneManager.LoadScene("mainmenu");
    }

  }
}
