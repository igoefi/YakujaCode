using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePLayer : MonoBehaviour
{
    public float speed = 250;
    Rigidbody2D _body;
    Animator _anim;
    float ScaleX;
    float ScaleY;

    public bool checkHomus;
    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        ScaleX = transform.localScale.x;
        ScaleY = transform.localScale.y;
    }
    private void Update()
    {
        if (!checkHomus)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 500;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 250;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localScale = new Vector2(-ScaleX, ScaleY);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localScale = new Vector2(ScaleX, ScaleY);
            }
            if (!GetComponent<PLayerAttack>().GetInAttack())
            {
                float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

                if (deltaX != 0)
                {
                    _anim.SetBool("Run", true);
                    _body.velocity = new Vector2(deltaX, 0);
                }
                else
                {
                    _anim.SetBool("Run", false);
                }
            }
        }
    }
}
