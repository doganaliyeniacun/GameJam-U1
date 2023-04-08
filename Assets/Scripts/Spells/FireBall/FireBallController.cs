using UnityEngine;

public class FireBallController : MonoBehaviour
{
    [SerializeField] private GameObject fireBallPrefab;
    [SerializeField] private GameObject fireBallSpawnPoint;
    [SerializeField] private float fireBallRadius;
    [SerializeField] private LayerMask enemyLayerMask;



    public void CanFire()
    {
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, fireBallRadius, enemyLayerMask);

        if (enemy)
        {
            fireBallPrefab.GetComponent<FireBall>().enemyPos = enemy.gameObject;
            GameObject fireBall = Instantiate(fireBallPrefab, fireBallSpawnPoint.transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, fireBallRadius);
    }
}
