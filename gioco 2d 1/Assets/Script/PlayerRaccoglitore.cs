using UnityEngine;

public class PlayerRaccoglitore : MonoBehaviour
{
    [SerializeField] Transform Meta;
    public bool controllo => chiave != null;
    GameObject chiave;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!controllo && collision.TryGetComponent(out Chiave chiave))
        {
            chiave.transform.SetParent(Meta);
            chiave.transform.localPosition = Vector3.zero;
            this.chiave = chiave.gameObject;
        }
        if (controllo && collision.TryGetComponent(out Serratura serratura))
        {
            serratura.Accettatore();
            Destroy(this.chiave);
            this.chiave = null;
        }
    }
}
