using UnityEngine;

public class Animazioni : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerAttack PlayerAttack;
    void Start()
    {
        PlayerAttack.AttackEvent += PlayerAttack_AttackEvent;
    }

    private void PlayerAttack_AttackEvent()
    {
        animator.SetTrigger("attacco");
    }
}
