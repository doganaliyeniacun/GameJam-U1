using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLock : MonoBehaviour
{
    [SerializeField] private float fireBallRadius = 10f;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private Transform parentTransform;

    private GameObject enemyPos;

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
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, fireBallRadius, enemyLayerMask);

        if (enemy)
        {
            enemyPos = enemy.gameObject;
        }
    }

    private void LockTarget()
    {
        if (!enemyPos)
        {
            return;
        }

        Vector3 direction = enemyPos.transform.position - transform.position;

        float rot = 0;

        if (parentTransform.localScale.x > 0)
        {
            rot = Mathf.Atan2(direction.y + 2, direction.x) * Mathf.Rad2Deg;
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
