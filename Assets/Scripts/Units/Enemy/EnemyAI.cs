using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("[Setting]")]
    [Range(1f, 10f)]
    [SerializeField] private float radius = 5f;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody2D rb2;
    private EnemyAnimation enemyAnimation;

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void FixedUpdate()
    {
        FindAndFollow();
    }

    private void FindAndFollow()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, radius, playerLayerMask);

        if (player)
        {
            enemyAnimation.Move(true);

            Vector2 playerPos = player.gameObject.transform.position;
            playerPos.y = transform.position.y;

            rb2.MovePosition(Vector2.MoveTowards(transform.position, playerPos, _moveSpeed * Time.deltaTime));

            Direction(playerPos - (Vector2)transform.position);
        }
        else
        {
            enemyAnimation.Move(false);
        }
    }

    private void Direction(Vector2 direction)
    {
        if (direction.x > 0)
        {
            Vector2 newScale = new Vector2(1f, transform.localScale.y);
            transform.localScale = newScale;
        }
        else if (direction.x < 0)
        {
            Vector2 newScale = new Vector2(-1f, transform.localScale.y);
            transform.localScale = newScale;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}