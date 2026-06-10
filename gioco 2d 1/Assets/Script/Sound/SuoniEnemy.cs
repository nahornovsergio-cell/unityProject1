using UnityEngine;

public class SuoniEnemy : MonoBehaviour
{
    private IenemyAttacco ienemy;
    [SerializeField] AudioSource FonteWizzard;
    [SerializeField] AudioClip suoniWizzard;

    void Start()
    {
        ienemy = GetComponentInParent<IenemyAttacco>();
        Debug.Log(ienemy == null);
        ienemy.Attacco += Ienemy_Attacco;
    }

    private void Ienemy_Attacco()
    {
        FonteWizzard.PlayOneShot(suoniWizzard);
    }

    void Update()
    {
        
    }
}
