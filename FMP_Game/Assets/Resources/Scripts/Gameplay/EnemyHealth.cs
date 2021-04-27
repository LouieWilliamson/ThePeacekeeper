﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    private bool isDead;
    public bool ShouldExplode;
    private HitEffect hitEffect;
    public GameObject deathFXPrefab;
    private GameObject deathFX;
    private EnemyAnimations anim;
    private PolygonCollider2D col;
    private Rigidbody2D rb;
    public float deathYchange;
    private HUDManager hud;
    private EnemyAI ai;
    private AudioManager sound;
    void Start()
    {
        isDead = false;
        hud = GameObject.Find("Canvas").GetComponent<HUDManager>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<PolygonCollider2D>();
        anim = GetComponent<EnemyAnimations>();
        health = 200;
        hitEffect = GetComponent<HitEffect>();
        ai = GetComponent<EnemyAI>();
        sound = GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (!isDead)
            {
                Kill();
                isDead = true;
            }
        }
    }

    public void ApplyDamage(int damage)
    {
        health += -damage;
        hitEffect.Enable();
        anim.HitAnim();
        sound.PlaySFX(AudioManager.SFX.HitEnemy);

    }
    private void Kill()
    {
        if (ShouldExplode)
        {
            deathFX = Instantiate(deathFXPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            anim.DeadAnim();
            col.enabled = false;
            rb.gravityScale = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y - deathYchange, transform.position.z);
        }
        sound.PlaySFX(AudioManager.SFX.EnemyDeath);
        hud.IncreaseEnemiesKilled();
        ai.SetDead();
    }
}
