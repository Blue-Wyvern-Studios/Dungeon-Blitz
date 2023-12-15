using UnityEngine.UI;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public GameObject canvas;
    public Button botonActivacion;

    void Start()
    {
        canvas.SetActive(false);
        botonActivacion.onClick.AddListener(ActivarCanvas);
    }

    public void ActivarCanvas()
    {
        canvas.SetActive(true);
    }
}
