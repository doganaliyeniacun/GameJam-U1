using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [HideInInspector]
    public GameObject enemyPos;

    private Rigidbody2D rb2;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        FindAndFollow();
    }

    private void FindAndFollow()
    {
        Vector3 direction = enemyPos.transform.position - transform.position;
        rb2.velocity = new Vector2(direction.x, direction.y).normalized * moveSpeed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Explosive();
        }
    }

    private void Explosive()
    {
        Destroy(gameObject);
    }
}
