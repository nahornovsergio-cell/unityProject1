using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    private List<IDamagable> damagablesInRange = new();
    private InputReader inputReader;

    private int count;
    private int level;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI levelText;
    public event Action AttackEvent;

    void Start()
    {
        // Сначала обнуляем, потом обновляем текст
        count = 0;
        level = 1; // Уровень обычно начинается с 1
        setMoneyText();
        setLevelText();
        foreach (GameObject item in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            InputReader Maneger = item.GetComponent<InputReader>();
            if (Maneger != null)
            {
                inputReader = Maneger;
                inputReader.AttackEvent += OnAttack;
                break;
            }
            
        }
    }

    public void setMoneyText()
    {
        if (moneyText != null)
            moneyText.text = "Soldi = " + count.ToString();
    }

    public void setLevelText()
    {
        if (levelText != null)
            levelText.text = "Level = " + level.ToString();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        if (inputReader != null) inputReader.AttackEvent -= OnAttack;
    }

    private void OnAttack()
    {
        AttackEvent?.Invoke();
        Debug.Log("ON attack!");
        // Проходим по списку врагов в радиусе
        for (int i = damagablesInRange.Count - 1; i >= 0; i--)
        {
            var damagable = damagablesInRange[i];

            // Проверка: не удален ли объект (например, другим скриптом)
            if (damagable == null || (damagable as MonoBehaviour) == null)
            {
                damagablesInRange.RemoveAt(i);
                continue;
            }

            // Наносим урон
            damagable.TakeDamage(10);
            Debug.Log("Hit enemy!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            if (!damagablesInRange.Contains(damagable))
            {
                damagablesInRange.Add(damagable);
                Debug.Log("Enemy in range");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            damagablesInRange.Remove(damagable);
            Debug.Log("Enemy left range");
        }
    }
}