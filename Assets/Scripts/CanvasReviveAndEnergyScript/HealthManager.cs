
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [Header("Character's Life")]
    public Image healthBar;
    public float healthAmount = 100f;
    public int maxHealth = 100;
    public TMP_Text hpText;

    [Header("Life Regeneration Variables")]
    public bool isPlayerAlive = true;
    private void Start()
    {
        hpText.text = healthAmount.ToString() + "/" + maxHealth.ToString();
        RegenerateLife.OnHealthRegeneration += RegenerateHealthExternally;
    }
    private void Update()
    {
        UpdateHealthDisplay();
    }
    public void TakeDamage(float damage)
    {

        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        UpdateHealthUI();
    }
    public void Heal(float healingAmount)
    {

        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);

        UpdateHealthUI();
    }
    public void UpdateHealthUI()
    {
        healthBar.fillAmount = healthAmount / maxHealth;
        hpText.text = healthAmount.ToString() + "/" + maxHealth.ToString();
    }
    public void RevivePlayer()
    {
        healthAmount = 100;
        isPlayerAlive = true;

    }
    void UpdateHealthDisplay()
    {
        UpdateHealthBar();
        UpdateHealthText();

        if (healthAmount <= 0 && isPlayerAlive)
        {
            isPlayerAlive = false;
        }
    }
    void UpdateHealthBar()
    {
        healthBar.fillAmount = Mathf.Clamp(healthAmount / maxHealth, 0, 1);
    }

    void UpdateHealthText()
    {
        hpText.text = healthAmount.ToString() + "/" + maxHealth.ToString();
    }
    void RegenerateHealthExternally(float amount)
    {

        Heal(amount);
        UpdateHealthUI();
        UpdateHealthBar(); 
    }
}