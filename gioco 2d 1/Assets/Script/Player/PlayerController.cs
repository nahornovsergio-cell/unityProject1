using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]SpriteRenderer sprite;
    [SerializeField]Animator animator;
    public float moveSpeed = 5f;
    public int maxHealth = 100;
    [SerializeField]AudioSource FonteSuonoPassi;
    [SerializeField]AudioClip suoniPassi;

    private int currentHealth;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Slider healthSlider;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage =20;
    public LayerMask enemyLayers;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        if(healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    void Update()
    {
       
        movement.x = Input.GetAxisRaw("Horizontal");
        sprite.flipX = movement.x < 0? true : movement.x > 0? false : sprite.flipX;
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        if (movement == Vector2.zero)
        {
            if (FonteSuonoPassi.isPlaying)
            {
                StopPassi();

            }
        }
        else
        {
            if (!FonteSuonoPassi.isPlaying)
            {
                PlayPassi();
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            //Attack();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }

public AttackZone weaponZone; // Перетащи сюда объект с триггером в инспекторе


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void PlayPassi()
    {
        FonteSuonoPassi.clip = suoniPassi;
        FonteSuonoPassi.Play();
        animator.SetBool("corre", true);


    }
    void StopPassi()
    {
        FonteSuonoPassi.Stop();
        animator.SetBool("corre", false);
    }

}
