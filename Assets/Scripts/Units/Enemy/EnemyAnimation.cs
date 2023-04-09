using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Move(bool checkMove)
    {
        anim.SetBool("Move", checkMove);
    }

    public void Die()
    {
        anim.SetTrigger("Die");
    }
}
