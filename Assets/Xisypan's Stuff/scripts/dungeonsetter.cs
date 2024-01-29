using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungeonsetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    GameObject startpoint = GameObject.Find("starterpoint");
    GameObject.Find("Player").transform.position = new Vector3(startpoint.transform .position.x,startpoint.transform.position.y,-5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
