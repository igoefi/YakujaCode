using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject LevelUpImage;

    public float EXP;
    private float needEXP;

    public float HP;
    public float maxHP = 100;

    public float damage;

    private bool life = true;

    public int level;
    Animator _anim;
    private void Start()
    {
        HP = maxHP;
        _anim = GetComponent<Animator>();
        EXP = 0;
        damage = 10;
        needEXP = 100;
        level = 1;
       }

    private void Update()
    {
        if(EXP >= needEXP)
        {
            level++;
            damage += 5;
            maxHP += 10;
            EXP -= needEXP;
            needEXP += 20;
            HP = maxHP;
            StartCoroutine(levelUpWait());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            EXP += 20;
        }
    }

    public void Hit(float damage)
    {
        HP -= damage;
        if (HP > 0)
        {
            _anim.SetTrigger("Hit");
        }
        else if(life)
        {
            _anim.SetTrigger("Dead");
            life = false;
        }
    }
    
    public void Dead()
    {
        gameObject.SetActive(false);
    }

    IEnumerator levelUpWait()
    {
        LevelUpImage.SetActive(true);
        yield return new WaitForSeconds(1);
        LevelUpImage.SetActive(false);
    }
}
