using UnityEngine.UI;
using UnityEngine;

public class ChangeSlots : MonoBehaviour
{
    public Button boton1;
    public Button boton2;
    public Button boton3;
    public Button boton4;
    public Button boton5;

    public GameObject objetoBoton1;
    public GameObject objetoBoton2;
    public GameObject objetoBoton3;
    public GameObject objetoBoton4;
    public GameObject objetoBoton5;

    void Start()
    {

        boton1.onClick.AddListener(() => ActivarObjeto(objetoBoton1));
        boton2.onClick.AddListener(() => ActivarObjeto(objetoBoton2));
        boton3.onClick.AddListener(() => ActivarObjeto(objetoBoton3));
        boton4.onClick.AddListener(() => ActivarObjeto(objetoBoton4));
        boton5.onClick.AddListener(() => ActivarObjeto(objetoBoton5));
 
    }

    public void ActivarObjeto(GameObject objetoAActivar)
    {

        objetoBoton1.SetActive(false);
        objetoBoton2.SetActive(false);
        objetoBoton3.SetActive(false);
        objetoBoton4.SetActive(false);
        objetoBoton5.SetActive(false);


        objetoAActivar.SetActive(true);
    }
}
