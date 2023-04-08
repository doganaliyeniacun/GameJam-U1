using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("[Setting]")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float groundRadius = 0.1f;
    [SerializeField] private GameObject groundCheckPoint;


    private Rigidbody2D rb2;
    private Vector2 moveInput;
    private PlayerAnimations anim;
    private bool isGrounded;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimations>();
    }

    private void FixedUpdate()
    {
        isGrounded = IsGrounded();
    }

    private void Update()
    {
        CanMove(moveInput, moveSpeed);
        Direction(moveInput.x);
        anim.GroundCheck(isGrounded);
    }

    public void Move(Vector2 input)
    {
        moveInput = input;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb2.AddForce(new Vector2(rb2.velocity.x, jumpForce), ForceMode2D.Impulse);
            AudioManager.Instance.PlaySFX("Jump");
            anim.Jump();

        }
    }

    private void CanMove(Vector2 input, float moveSpeed)
    {
        rb2.velocity = new Vector2(moveInput.x * moveSpeed, rb2.velocity.y);

        if (isGrounded)
        {
            anim.Move(Mathf.Abs(input.x));
        }
    }

    private void Direction(float direction)
    {
        if (direction != 0)
        {
            Vector2 newScale = new Vector2(direction, transform.localScale.y);
            transform.localScale = newScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.transform.position, groundRadius, groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheckPoint.transform.position, groundRadius);
    }
}
