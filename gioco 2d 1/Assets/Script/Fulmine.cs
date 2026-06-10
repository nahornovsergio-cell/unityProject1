using UnityEngine;

public class Fulmine : MonoBehaviour
{
    [SerializeField]int damage;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
