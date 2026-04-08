using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 10;
    public float lifeTime = 5f;

    private Vector2 direction;

    public void Init(Vector2 targetPosition)
    {
        direction = (targetPosition - (Vector2)transform.position).normalized;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Если попали в игрока
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
        // Проверяем, что фаербол не попал в того, кто его выпустил (врага)
        // В данном случае, если мы хотим, чтобы игрок только бил мечом, 
        // фаербол вообще не должен реагировать на тег Enemy
    }

}