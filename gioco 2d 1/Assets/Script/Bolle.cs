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
}
