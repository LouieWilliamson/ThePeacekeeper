﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    EnemyAnimations anim;
    public int speed;
    private int walkSpeed;
    private int runSpeed;
    public int jumpHeight;

    private bool walking;
    
    void Start()
    {
        walking = true;
        anim = GetComponent<EnemyAnimations>();
        rb = GetComponent<Rigidbody2D>();
        runSpeed = speed * 2;
        walkSpeed = speed;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            Move(false);
        }
        if (Input.GetKey(KeyCode.L))
        {
            Move(true);
        }

        //if(!Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.Space))
        //{
        //    anim.Idle();
        //    StopHorizontal();
        //}

        if (Input.GetKeyDown(KeyCode.O))
        {
            Jump();
        }
        
    }
    public void SetWalking(bool isWalking)
    {
        walking = isWalking;
    }
    public void Move(bool RightIfTrue)
    {
        if (walking)
        {
            anim.Walk();
            speed = walkSpeed;
        }
        else
        {
            anim.Run();
            speed = runSpeed;
        }

        if(RightIfTrue)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }
    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpHeight));
        anim.Jump();
    }
    public void StopHorizontal()
    {
        Vector2 stopHor = new Vector2(0, rb.velocity.y);
        rb.velocity = stopHor;
    }
    public void SetIgnorePlayer(GameObject player)
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        GetComponent<EnemyAI>().SetPlayer(player);
    }
}
