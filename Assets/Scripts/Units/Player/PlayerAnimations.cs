using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Move(float speed)
    {
        anim.SetFloat("Speed", speed);
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }

    public void GroundCheck(bool check)
    {
        anim.SetBool("isGrounded",check);
    }
}
