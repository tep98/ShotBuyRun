using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public GameObject playerSprite;
    private Renderer playerSpriteRenderer;

    public GameObject takeDamageSound;

    public GameObject bulletHitEffect;

    public float startTimeBtwDamage;
    private float timeBtwDamage;

    public GameObject HeartUI;
    private Animator HeartAnim;

    private Health health;
    private float hp;
    private float maxHP;
    public bool isExit = true;

    public float damageByPillager;

    private void Start()
    {
        health = GetComponent<Health>();
        playerSpriteRenderer = playerSprite.GetComponent<Renderer>();
        timeBtwDamage = 0;
        HeartAnim = HeartUI.GetComponent<Animator>();
        maxHP = health.HP;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (timeBtwDamage <= 0)
            {
                timeBtwDamage = startTimeBtwDamage;
                DamageFunction();
            }
            else
            {
                timeBtwDamage -= Time.deltaTime;
            }
        }    
    }

    public void DamageFunction()
    {
        health.GetDamage(damageByPillager);
        playerSpriteRenderer.material.SetColor("_Color", new Color(200 / 255.0f, 83 / 255.0f, 83 / 255.0f));
        Invoke("SetDefaultColor", 0.2f);

        HeartAnim.SetTrigger("takeDamage");

        Instantiate(takeDamageSound, transform.position, Quaternion.identity);
        Instantiate(bulletHitEffect, transform.position, Quaternion.identity);

        if (health._hp < (maxHP / 2))
        {
            HeartAnim.SetBool("lowHP", true);
        }
        else
        {
            HeartAnim.SetBool("lowHP", false);
        }
    } 

    private void SetDefaultColor()
    {
        playerSpriteRenderer.material.SetColor("_Color", Color.white);
    }

    private void SetIsExit()
    {
        isExit = true;
    }
}