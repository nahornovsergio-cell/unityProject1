using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
public class PlayerHealth : Health
{
    [SerializeField] private Slider hpSlider;

    protected override void Start()
    {
        base.Start(); // Выполняем базовую установку HP
        UpdateUI();
    }

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        UpdateUI();
    }

    public override void Heal(int healAmount)
    {
        base.Heal(healAmount);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (hpSlider != null)
        {
            hpSlider.maxValue = maxHealth;
            hpSlider.value = currentHealth;
        }
    }

    protected override void Die()
    {
        Debug.Log("Игрок погиб! Перезагрузка...");
        // Перезагружаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}