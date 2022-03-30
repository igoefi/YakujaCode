using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    public float attackPointRange = 1;

    public float damage = 10;

    public float attackRate = 1f;
    private float nextAttackTime = 0;

    private Transform TransformPlayer;

    private float speed = 200;

    public float agressiveDistance = 10;
    public float attackDistance = 2;
    Rigidbody2D _body;
    Animator _anim;

    public LayerMask PlayerLayer;

    private float ScaleX;
    private float ScaleY;
    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        ScaleX = transform.localScale.x;
        ScaleY = transform.localScale.y;
    }
    private void Update()
    {
        Vector2 RayOrigin = new Vector2(transform.position.x, transform.position.y);
        Debug.DrawRay(RayOrigin, transform.right*9);
        RaycastHit2D[] hit = Physics2D.RaycastAll(RayOrigin, transform.right * 9);

        foreach(RaycastHit2D enemy in hit)
        {
            Collider2D enemyCollider = enemy.collider;
            if(enemyCollider.GetComponent<Player>() != null)
            {
                TransformPlayer = enemy.transform;
                
            }
        }


        float distanceToPlayer = Vector2.Distance(RayOrigin, TransformPlayer.position);
        if (distanceToPlayer <= attackDistance)
        {
            _anim.SetBool("Run", false);
            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + attackRate;
                Attack();
            }
        }
        else if (distanceToPlayer <= agressiveDistance)
        {
            StartChaise();
        }
        else
        {
            TransformPlayer = null;
            _anim.SetBool("Run", false);
        }

    }

    private void StartChaise()
    {
        _anim.SetBool("Run", true);
        if (transform.position.x < TransformPlayer.position.x)
        {
            transform.localScale = new Vector2(ScaleX, ScaleY);
            _body.velocity = new Vector2(speed*Time.deltaTime, 0);
        }
        else
        {
            transform.localScale = new Vector2(-ScaleX, ScaleY);
            _body.velocity = new Vector2(-speed * Time.deltaTime, 0);
        }
    }

    private void Attack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackPointRange, PlayerLayer);

        foreach (Collider2D enemy in hit)
        {
            if (enemy.GetComponent<Player>() != null)
            {
                _anim.SetTrigger("Attack");
                enemy.GetComponent<Player>().Hit(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackPointRange);
    }
}
