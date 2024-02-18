using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{
    public GameObject objetoParaOcultar;
    public ChangeSlots changeSlotsScript; 

    void Start()
    {
        changeSlotsScript = GameObject.FindObjectOfType<ChangeSlots>();
    }

    public void OcultarMostrarObjetoCanvas()
    {
        objetoParaOcultar.SetActive(!objetoParaOcultar.activeSelf);

        if (!objetoParaOcultar.activeSelf && changeSlotsScript != null)
        {
            changeSlotsScript.ActivarObjeto(changeSlotsScript.objetoBoton1);
        }
    }
}
