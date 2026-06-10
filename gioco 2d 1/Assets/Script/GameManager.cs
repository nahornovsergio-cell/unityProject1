using System.Collections.Generic; // Нужно для списков
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int enemyCount => activeEnemies.Count;

    public List<GameObject> activeEnemies = new List<GameObject>();
    public bool openGate = false;
    public List<GameObject> deactivableObjects = new List<GameObject>();
    public Serratura serratura;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        if (serratura != null)
        {
            serratura.RaccoltoTutto += Serratura_raccoltoTutto;
        }
    }

    private void Serratura_raccoltoTutto()
    {   
        foreach (GameObject obj in deactivableObjects) 
        {
            GameObject.Destroy(obj);
        }
    }

    void Start()
    {
        // Находим всех врагов и добавляем в список
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        activeEnemies.AddRange(enemies);
        Debug.Log("Врагов в списке: " + activeEnemies.Count);
    }

    public void EnemyKilled(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
            Debug.Log($"Враг убит! Осталось: {activeEnemies.Count}");
        }

        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (activeEnemies.Count <= 0)
        {
            openGate = true;
            Debug.Log("Все враги повержены! Ворота открыты.");
        }
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            Debug.Log("Игра возобновлена");
        }
        else
        {
            Time.timeScale = 0f;
            Debug.Log("Игра на паузе");
        }
    }
}