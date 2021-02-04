﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    bool isFacingLeft;
    Rigidbody2D m_rb;
    Animator m_Anim;
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();
        isFacingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    private void FlipSprite()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
