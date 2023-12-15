using UnityEngine;
using UnityEngine.UI;

public class ClassChange : MonoBehaviour
{
    public Button boton1;
    public Button boton2;
    public Button boton3;
    public Button boton4;

    public GameObject objetoBoton1;
    public GameObject objetoBoton2;
    public GameObject objetoBoton3;
    public GameObject objetoBoton4;

    void Start()
    {

        boton1.onClick.AddListener(() => ActivarObjeto(objetoBoton1));
        boton2.onClick.AddListener(() => ActivarObjeto(objetoBoton2));
        boton3.onClick.AddListener(() => ActivarObjeto(objetoBoton3));
        boton4.onClick.AddListener(() => ActivarObjeto(objetoBoton4));

    }

    public void ActivarObjeto(GameObject objetoAActivar)
    {

        objetoBoton1.SetActive(false);
        objetoBoton2.SetActive(false);
        objetoBoton3.SetActive(false);
        objetoBoton4.SetActive(false);


        objetoAActivar.SetActive(true);
    }
}

