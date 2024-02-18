using UnityEngine.UI;
using UnityEngine;

public class RegenerateLife : MonoBehaviour
{
    public HealthManager healthManager;
    public float regenerationAmount = 10f; 
    public float regenerationInterval = 5f; 
    public Image healthBarFill;
    public delegate void HealthRegenerationAction(float amount);
    public static event HealthRegenerationAction OnHealthRegeneration;
    private void Start()
    {
        InvokeRepeating("RegenerateHealth", regenerationInterval, regenerationInterval);
    }

    void RegenerateHealth()
    {
        if (healthManager.isPlayerAlive && OnHealthRegeneration != null)
        {
            if (healthManager.healthAmount < healthManager.maxHealth)
            {
                OnHealthRegeneration(regenerationAmount);
            }
        }
    }
    void UpdateHealthBarUI()
    {
        if (healthBarFill != null && healthManager != null)
        {
            float fillAmount = healthManager.healthAmount / healthManager.maxHealth;
            healthBarFill.fillAmount = fillAmount;
        }
    }
}
