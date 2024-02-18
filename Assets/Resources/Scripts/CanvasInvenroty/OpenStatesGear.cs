using UnityEngine.UI;
using UnityEngine;

public class OpenStatesGear : MonoBehaviour
{
    public GameObject objetos;
    public Button botonActivacion;

    void Start()
    {
        objetos.SetActive(false);
        botonActivacion.onClick.AddListener(ActivarCanva);
    }

    public void ActivarCanva()
    {
        objetos.SetActive(true);
        botonActivacion.onClick.RemoveListener(ActivarCanva);
        botonActivacion.onClick.AddListener(DesactivarCanva);
    }

    public void DesactivarCanva()
    {
        objetos.SetActive(false);
        botonActivacion.onClick.RemoveListener(DesactivarCanva);
        botonActivacion.onClick.AddListener(ActivarCanva);
    }
}
