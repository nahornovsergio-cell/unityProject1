using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] PlayerAttack PlayerAttack;
    [SerializeField] AudioSource FonteSuonoAttacco;
    [SerializeField] AudioClip suoniAttacco;
    void Start()
    {
        PlayerAttack.AttackEvent += PlayAttacco;
    }

    void Update()
    {
        
    }
    void PlayAttacco()
    {
        FonteSuonoAttacco.pitch = Random.Range(0.8f, 1f);
        FonteSuonoAttacco.PlayOneShot(suoniAttacco);
    }
}
