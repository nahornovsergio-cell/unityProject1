using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamagable, IHealable
{
    [SerializeField] Slider healthSlider;
    [SerializeField] protected int maxHealth = 100; // protected — чтобы наследники видели переменную
    protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        if (healthSlider != null)
        {
        healthSlider.maxValue = maxHealth;
        }
    }

    public virtual void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log($"{gameObject.name} получил урон. ХП: {currentHealth}");
        CheckHealth();
        UpdateSlider();
    }

    public virtual void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }

    protected virtual void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Базовая логика смерти — просто удаление
        Destroy(gameObject);
    }

    private void UpdateSlider()
    {
        if (healthSlider != null) 
        {
            healthSlider.value = maxHealth - currentHealth;
        }
    }
}