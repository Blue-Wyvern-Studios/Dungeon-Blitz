using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    [SerializeField] private GameObject worldMap;

    public bool isMapOpen { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        CloseWorldMap();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleWorldMap();
        }
    }

    public void ToggleWorldMap()
    {
        if (!isMapOpen)
        {
            OpenWorldMap();
        }
        else
        {
            CloseWorldMap();
        }
    }

    private void OpenWorldMap()
    {
        worldMap.SetActive(true);
        isMapOpen = true;
    }

    public void CloseWorldMap()
    {
        worldMap.SetActive(false);
        isMapOpen = false;
    }
}
