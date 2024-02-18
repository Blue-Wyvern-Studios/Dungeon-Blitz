using UnityEngine.UI;
using UnityEngine;

public class CloseBook : MonoBehaviour
{
    public GameObject objetoParaOcultar;
    public ClassChange changeClassScript;

    void Start()
    {
        changeClassScript = GameObject.FindObjectOfType<ClassChange>();
    }

    public void OcultarMostrarObjetoCanvas()
    {
        objetoParaOcultar.SetActive(!objetoParaOcultar.activeSelf);

        if (!objetoParaOcultar.activeSelf && changeClassScript != null)
        {
            changeClassScript.ActivarObjeto(changeClassScript.objetoBoton1);
        }
    }
}
