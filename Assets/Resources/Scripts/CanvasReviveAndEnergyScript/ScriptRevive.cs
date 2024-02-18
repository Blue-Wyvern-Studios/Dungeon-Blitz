using UnityEngine.UI;
using UnityEngine;

public class ScriptRevive : MonoBehaviour
{
    public Button reviveButton;
    public Canvas reviveCanvas;
    public float delayTime = 17f;

    private float startTime = 0f;
    private bool canInteract = false;

    private void Start()
    {
        if (reviveCanvas != null)
        {
            reviveCanvas.gameObject.SetActive(false);
        }

        if (reviveButton != null)
        {
            reviveButton.interactable = false;
            startTime = Time.time;
        }
    }

    private void Update()
    {
        HealthManager healthManager = FindObjectOfType<HealthManager>();
        if (healthManager != null)
        {
            if (healthManager.healthBar.fillAmount <= 0 && !healthManager.isPlayerAlive)
            {
                reviveCanvas.gameObject.SetActive(true);

                if (Time.time - startTime >= delayTime && !canInteract)
                {
                    canInteract = true;
                    reviveButton.interactable = true;
                }
            }
            else
            {
                reviveCanvas.gameObject.SetActive(false);
                startTime = Time.time;
                canInteract = false;
                reviveButton.interactable = false;
            }
        }
    }

    public void RevivePlayer()
    {
        HealthManager healthManager = FindObjectOfType<HealthManager>();
        if (healthManager != null)
        {
            healthManager.RevivePlayer();
            startTime = Time.time; 
            canInteract = false;
            reviveButton.interactable = false;
        }
    }
}