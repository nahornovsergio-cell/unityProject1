using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]SpriteRenderer sprite;
    [SerializeField]Animator animator;
    public float moveSpeed = 5f;
    public int maxHealth = 100;
    [SerializeField]AudioSource FonteSuonoPassi;
    [SerializeField]AudioClip suoniPassi;
    [SerializeField]InputActionAsset action;

    private int currentHealth;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Slider healthSlider;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage =20;
    public LayerMask enemyLayers;
    [SerializeField] GameObject pannelloMorte;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        if(healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
        action.actionMaps[0].actions.First(x => x.name == "Attack").performed += PlayerController_performed;
    }

    private void PlayerController_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("attacco");
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
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        StartCoroutine(rovinato());
    }
    IEnumerator rovinato()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        sprite.color = Color.white;
    }

    void Die()
    {
        Debug.Log("Player died");
        showScreen();


    }

     public AttackZone weaponZone; // Перетащи сюда объект с триггером в инспекторе


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void PlayPassi()
    {
        FonteSuonoPassi.pitch = Random.Range(0.8f, 2f);
        FonteSuonoPassi.clip = suoniPassi;
        FonteSuonoPassi.Play();
        animator.SetBool("corre", true);


    }
    void StopPassi()
    {
        FonteSuonoPassi.Stop();
        animator.SetBool("corre", false);
    }
    public void showScreen()
    {
        pannelloMorte.SetActive(true);
    }
    public void highScreen()
    {
        SceneManager.LoadScene(1);
    }

}