using UnityEngine.UI;
using UnityEngine;

public class ScriptEnergyBar : MonoBehaviour
{
    public Image imagenBarraEnergia; 

    public void ActualizarEnergia(float nuevoNivel)
    {
        nuevoNivel = Mathf.Clamp01(nuevoNivel);

        imagenBarraEnergia.fillAmount = nuevoNivel;
    }
    void Start()
    {
        ActualizarEnergia(0.5f); 
    }
}
