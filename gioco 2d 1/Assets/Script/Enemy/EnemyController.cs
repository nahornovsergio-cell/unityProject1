using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    //public int maxHealth = 50;

    public float attackRange = 6f;
    public float castCooldown = 2f;

    public GameObject fireballPrefab;
    public Transform firePoint;

    private Transform player;
    private float lastCastTime;
    //private int currentHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //currentHealth = maxHealth;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            MoveToPlayer();
        }
        else
        {
            TryCastFireball();
        }
    }

    void MoveToPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }

    void TryCastFireball()
    {
        if (Time.time - lastCastTime >= castCooldown)
        {
            lastCastTime = Time.time;
            CastFireball();
        }
    }

    void CastFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        fireball.GetComponent<Fireball>().Init(player.position);
    }

   // public void TakeDamage(int damage)
   // {
   //     currentHealth -= damage;
   //     if (currentHealth <= 0)
   //     {
   //         Die();
   //     }
   //}

   //// void Die()
   // /{
   //     Destroy(gameObject);
   // }
}