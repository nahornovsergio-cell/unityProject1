using System;
using UnityEngine;
using UnityEngine.UI;

public class MeleeEnemyController : MonoBehaviour
{
    [Header("Stats")]
    public Enemyconfig config;
    private int currentHealth;
    public Slider healthSlider;

    [Header("Combat")]
    public int contactDamage = 10;      // Урон при касании
    public float damageCooldown = 1f;   // Как часто он может кусать игрока
    private float lastDamageTime;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = config.maxHealth;
       
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
        if (healthSlider != null)
        {
            healthSlider.maxValue = config.maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;
        FixUIRotation();

        // Движение через Rigidbody2D (так физика работает стабильнее)
        Vector2 direction = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * config.moveSpeed * Time.fixedDeltaTime);

        // Поворот спрайта
        if (direction.x > 0.1f) transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (direction.x < -0.1f) transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void FixUIRotation()
    {
        if (healthSlider == null)
        {
            return;
        }

        healthSlider.transform.parent.localScale = new Vector3(
        Mathf.Abs(healthSlider.transform.parent.localScale.x),
        healthSlider.transform.parent.localScale.y,
        healthSlider.transform.parent.localScale.z);
        healthSlider.transform.parent.rotation = Quaternion.identity;
    }

    // ГЛАВНАЯ ЧАСТЬ: Урон при столкновении
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                // Пытаемся нанести урон
                collision.gameObject.GetComponent<PlayerController>()?.TakeDamage(contactDamage);
                lastDamageTime = Time.time;
                Debug.Log("Враг укусил игрока!");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        Debug.Log("Враг повержен!");
        Destroy(gameObject);
    }
}