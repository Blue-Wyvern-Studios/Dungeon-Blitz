using UnityEngine.UI;
using UnityEngine;

public class OpenCanvasFriends : MonoBehaviour
{
    public GameObject canvas;
    public Button botonActivacion;

    private bool canvasActivo = false;

    void Start()
    {
        canvas.SetActive(canvasActivo);
        botonActivacion.onClick.AddListener(ToggleCanvas);
    }

    public void ToggleCanvas()
    {
        canvasActivo = !canvasActivo; 

        canvas.SetActive(canvasActivo); 
    }
}
