using System.Collections;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    [SerializeField] private GameObject fireBallPrefab;
    [SerializeField] private GameObject fireBallSpawnPoint;
    [SerializeField] private float spellRadius;
    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private float coolDownTime = 1f;
    [SerializeField] private Transform parentTransform;

    private bool canFire = true;

    public void CanFire()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, spellRadius, targetLayerMask);
        Collider2D target = new Collider2D();
        
        if (targets.Length <= 0)
        {
            return;    
        }

        foreach (Collider2D item in targets)
        {
            if (item.CompareTag("Enemy") && item.gameObject.GetComponent<EnemyAI>().brainless)
            {
                target = item;
            }            

            if (item.CompareTag("Player"))
            {
                target = item;
            }            
        }

        if (target && canFire)
        {
            fireBallPrefab.GetComponent<Spell>().targetPos = target.gameObject;
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
        Gizmos.DrawWireSphere(transform.position, spellRadius);
    }
}
