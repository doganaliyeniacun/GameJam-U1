using System.Collections;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    [SerializeField] private GameObject fireBallPrefab;
    [SerializeField] private GameObject fireBallSpawnPoint;
    [SerializeField] private float fireBallRadius;
    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private float coolDownTime = 1f;
    [SerializeField] private Transform parentTransform;

    private bool canFire = true;

    public void CanFire()
    {
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, fireBallRadius, targetLayerMask);

        if (enemy && canFire)
        {
            fireBallPrefab.GetComponent<Spell>().targetPos = enemy.gameObject;
            fireBallPrefab.GetComponent<Spell>().directionX = parentTransform.localScale.x;
            GameObject fireBall = Instantiate(fireBallPrefab, fireBallSpawnPoint.transform.position, Quaternion.identity);
            

            StartCoroutine(CoolDown());
        }
    }

    private IEnumerator CoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(coolDownTime);
        canFire = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, fireBallRadius);
    }
}
