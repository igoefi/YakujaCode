using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float HP;
    public float maxHP = 100;

    Animator _anim;
    private void Start()
    {
        HP = maxHP;
        _anim = GetComponent<Animator>();
    }
    public float Hit(float damage)
    {
        HP -= damage;
        if (HP > 0)
        {
            _anim.SetTrigger("Hit");
            return 0;
        }
        else
        {
            _anim.SetTrigger("Dead");
            return 5;
        }
    }

    public void Destroy()
    {
        _anim.speed = 0;
        Destroy(gameObject.GetComponent<Enemy>());
        Destroy(gameObject.GetComponent<BasicEnemyAI>());
        Destroy(gameObject.GetComponent<CapsuleCollider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    }
}
