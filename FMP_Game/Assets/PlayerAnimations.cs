﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    Animator m_Anim;
    Rigidbody2D m_rb;

    bool isFacingLeft;

    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.velocity = Vector2.zero;
        isFacingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Is he moving?
        //if (m_rb.velocity.x != 0 || m_rb.velocity.y != 0)
        //{
        //    m_Anim.SetTrigger("isMoving");
        //    print("MOVE");
        //}
        //else
        //{
        //    m_Anim.SetTrigger("isIdle");
        //    print("IDLE");
        //}

        //if (m_rb.velocity.x < 0.1 && m_rb.velocity.x > -0.1)
        //{
        //    m_Anim.SetTrigger("isIdle");
        //    print("IDLE");
        //}
        //else
        //{
        //    m_Anim.SetTrigger("isMoving");
        //    print("MOVE");
        //}

        //Is he moving to the left
        if (m_rb.velocity.x < 0)
        {
            //is he already facing left?
            if (!isFacingLeft)
            {
                FlipSprite();
                isFacingLeft = true;
            }
        }
        else if (m_rb.velocity.x > 0)
        {
            if (isFacingLeft)
            {
                FlipSprite();
                isFacingLeft = false;
            }
        }
        print(m_rb.velocity.x);
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void SetGun(bool hasGun)
    {
        m_Anim.SetBool("hasGun", hasGun);
    }

    public void SetJumpAnim()
    {
        m_Anim.SetTrigger("isJumping");
    }

    public void SetMove()
    {
        m_Anim.SetTrigger("isMoving");
    }

    public void SetIdle()
    {
        m_Anim.SetTrigger("isIdle");
    }
}
