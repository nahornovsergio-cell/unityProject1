using UnityEngine;
using System;

public class EnemyController : MonoBehaviour, IenemyAttacco
{
    public float moveSpeed = 3f;
    //public int maxHealth = 50;

    public float attackRange = 6f;
    public float castCooldown = 2f;

    public GameObject fireballPrefab;
    public Transform firePoint;

    private PlayerController player;
    private float lastCastTime;

    public event Action Attacco;

    //private int currentHealth


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //currentHealth = maxHealth;
        Debug.Log(player);
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

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
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }

    void TryCastFireball()
    {
        if (!player.Alive)
        {
            return;
        }
        if (Time.time - lastCastTime >= castCooldown)
        {
            lastCastTime = Time.time;
            CastFireball();
        }
    }

    void CastFireball()
    {
        Attacco?.Invoke();
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        fireball.GetComponent<Fireball>().Init(player.transform.position);
    }
}