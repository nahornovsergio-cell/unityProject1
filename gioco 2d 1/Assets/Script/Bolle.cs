using UnityEngine;

public class Bolle : MonoBehaviour
{
    [SerializeField] float lifeTime;
    private float currentTimeLife;
    void Start()
    {
        
    }
    void Update()
    {
        currentTimeLife += Time.deltaTime;
        if (currentTimeLife > lifeTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(30);
        }
    }
}
