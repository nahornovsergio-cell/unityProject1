using UnityEngine;
using System.Collections.Generic;

public class AttackZone : MonoBehaviour
{
    // Список врагов, которые сейчас находятся в зоне меча
    public List<EnemyController> enemiesInZone = new List<EnemyController>();
    public List<MeleeEnemyController> meleeEnemiesInZone = new List<MeleeEnemyController>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy in zone");
        // Проверяем магов
        var mage = other.GetComponent<EnemyController>();
        if (mage != null) enemiesInZone.Add(mage);

        // Проверяем мечников
        var melee = other.GetComponent<MeleeEnemyController>();
        if (melee != null) meleeEnemiesInZone.Add(melee);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var mage = other.GetComponent<EnemyController>();
        if (mage != null) enemiesInZone.Remove(mage);

        var melee = other.GetComponent<MeleeEnemyController>();
        if (melee != null) meleeEnemiesInZone.Remove(melee);
    }
}