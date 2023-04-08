using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationAngle = -90f;
    [SerializeField] private float spellDamage = 25f;
    [SerializeField] private bool followTarget = true;
    [SerializeField] private bool isEnemySpell = false;

    public float directionX;
    [HideInInspector]
    public GameObject targetPos;

    private Rigidbody2D rb2;
    private SpriteRenderer sprite;


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        if (!followTarget)
        {
            MoveLeftOrRight();
        }

        Invoke(nameof(Explosive), 3);
    }

    private void FixedUpdate()
    {
        if (followTarget)
        {
            FindAndFollow();
        }
    }

    private void MoveLeftOrRight()
    {
        Vector2 newDirection = transform.localScale;

        if (directionX > 0)
        {
            newDirection.x = 1f;
        }
        else if (directionX < 0)
        {
            newDirection.x = -1f;
        }

        transform.localScale = newDirection;

        rb2.velocity = new Vector2(directionX, rb2.velocity.y).normalized * moveSpeed;
    }

    private void FindAndFollow()
    {
        Vector3 direction = targetPos.transform.position - transform.position;
        rb2.velocity = new Vector2(direction.x, direction.y).normalized * moveSpeed;

        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isEnemySpell)
        {
            other.GetComponent<BrainController>().TakeDamage(spellDamage);
            Explosive();
        }

        if (other.CompareTag("Player") && isEnemySpell)
        {
            Explosive();
        }
    }

    private void Explosive()
    {
        Destroy(gameObject);
    }
}
