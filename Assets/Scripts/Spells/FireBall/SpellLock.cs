using UnityEngine;

public class SpellLock : MonoBehaviour
{
    [SerializeField] private float spellRadius = 10f;
    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private Transform parentTransform;

    private GameObject targetPos;

    private void FixedUpdate()
    {
        FindTarget();
    }

    private void Update()
    {
        LockTarget();
    }

    private void FindTarget()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, spellRadius, targetLayerMask);
        Collider2D target = new Collider2D();

        foreach (Collider2D item in targets)
        {
            if (item.gameObject.GetComponent<EnemyAI>().brainless)
            {
                target = item;
            }            
        }

        if (target)
        {
            targetPos = target.gameObject;
        }
    }

    private void LockTarget()
    {
        if (!targetPos)
        {
            return;
        }

        Vector3 direction = targetPos.transform.position - transform.position;

        float rot = 0;

        if (parentTransform.localScale.x > 0)
        {
            rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // print("> 0");
        }
        else if (parentTransform.localScale.x < 0)
        {
            rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            // print("< 0");
        }

        transform.rotation = Quaternion.Euler(0, 0, rot);
    }
}
