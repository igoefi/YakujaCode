using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAttack : MonoBehaviour
{

    [SerializeField] Transform attackPoint;

    public float attackPointRange = 2;
    Animator _anim;
    bool inAttack = false;

    public float attackRate = 1f;
    private float nextAttackTime = 0;

    public float attackTime = 1;

    public LayerMask enemyLayer;

    public bool checkHomus;
    private void Start()
    {
        _anim = GetComponent<Animator>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !checkHomus)
        {
            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + attackRate;
                StartCoroutine(Attack());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackPointRange);
    }

    public bool GetInAttack()
    {
        return inAttack;
    }
    private IEnumerator Attack()
    {
        _anim.SetTrigger("Attack");
        inAttack = true;

        yield return new WaitForSeconds(0.3f);


        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackPointRange);

        foreach (Collider2D enemy in hit)
        {
            if (enemy.GetComponent<Enemy>() != null)
            {
                GetComponent<Player>().EXP += enemy.GetComponent<Enemy>().Hit(GetComponent<Player>().damage);
            }
        }

        yield return new WaitForSeconds(0.4f);

        inAttack = false;
    }
}
