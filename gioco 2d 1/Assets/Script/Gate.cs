using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    private Collider2D gateCollider;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        gateCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Срабатывает, когда кто-то (игрок) врезается в ворота
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Проверяем, что в ворота врезался именно игрок
        if (collision.gameObject.CompareTag("Player"))
        {
            CheckEnemies();
        }
    }

    void CheckEnemies()
    {
        // Ищем всех активных врагов на сцене прямо сейчас
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            // Если враги есть — выводим сообщение
            Debug.Log("Невозможно уйти с арены во время боя! Осталось врагов: " + enemies.Length);
        }
        else
        {
            Debug.Log("Cerco di caricare la scena seguente");
            int corrente = SceneManager.GetActiveScene().buildIndex;
            corrente++;
            // Если врагов нет — открываем ворота
            SceneManager.LoadScene(corrente);
        }
    }

    void Open()
    {
        if (gateCollider.enabled)
        {
            gateCollider.enabled = false; // Теперь можно пройти

            // Визуальный эффект открытия
            Color color = spriteRenderer.color;
            color.a = 0.3f;
            spriteRenderer.color = color;

            Debug.Log("Все враги повержены. Путь свободен!");
        }
    }
}