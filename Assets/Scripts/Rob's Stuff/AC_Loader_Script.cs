using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class AC_Loader_Script : MonoBehaviour
{
    void Start()
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
    }
}
