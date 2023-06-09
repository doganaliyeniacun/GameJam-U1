using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("[Setting]")]
    [Range(1f, 10f)]
    [SerializeField] private float radius = 5f;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private SpellController spellController;

    public bool brainless = true;

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

        if (brainless)
        {
            spellController.CanFire();
        }
        else
        {
            enemyAnimation.Die();
        }
    }


    private void FindAndFollow()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, radius, playerLayerMask);

        if (player && brainless)
        {
            Vector2 playerPos = player.gameObject.transform.position;
            playerPos.y = transform.position.y;

            float distance = Vector2.Distance(playerPos, transform.position);

            if (distance >= 5f)
            {
                enemyAnimation.Move(true);
                rb2.MovePosition(Vector2.MoveTowards(transform.position, playerPos, _moveSpeed * Time.deltaTime));
            }
            else
            {
                enemyAnimation.Move(false);
            }

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