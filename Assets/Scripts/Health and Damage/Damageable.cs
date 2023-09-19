using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public GameObject playerSprite;
    private Renderer playerSpriteRenderer;
    [SerializeField]
    private UnityEvent<float> DamageGot;

    public GameObject takeDamageSound;

    public GameObject bulletHitEffect;

    public float startTimeBtwDamage;
    private float timeBtwDamage;

    public GameObject HeartUI;
    private Animator HeartAnim;

    private float hp;
    private float maxHP;
    public bool isExit = true;

    private void Start()
    {
        playerSpriteRenderer = playerSprite.GetComponent<Renderer>();
        timeBtwDamage = startTimeBtwDamage;
        HeartAnim = HeartUI.GetComponent<Animator>();
        maxHP = GetComponent<Health>().HP;
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (isExit)
        {
            DamageFunction(other);
        }
        isExit = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (timeBtwDamage <= 0)
        {
            timeBtwDamage = startTimeBtwDamage;
            DamageFunction(other);
        }
        else
        {
            timeBtwDamage -= Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<BoxCollider2D>().TryGetComponent<AttackSystem>(out var attacksystem))
        {
            timeBtwDamage = startTimeBtwDamage;
            Invoke("SetIsExit", startTimeBtwDamage/1.5f);
        }
    }


    public void DamageFunction(Collider2D other)
    {
        if (other.GetComponent<BoxCollider2D>().TryGetComponent<AttackSystem>(out var attacksystem))
        {
            DamageGot?.Invoke(attacksystem.Damage);

            playerSpriteRenderer.material.SetColor("_Color", new Color(200 / 255.0f, 83 / 255.0f, 83 / 255.0f));
            Invoke("SetDefaultColor", 0.2f);

            Instantiate(takeDamageSound, transform.position, Quaternion.identity);
            Instantiate(bulletHitEffect, transform.position, Quaternion.identity);

            HeartAnim.SetTrigger("takeDamage");

            hp = GetComponent<Health>()._hp;
            if (hp < (maxHP / 2))
            {
                HeartAnim.SetBool("lowHP", true);
            }
            else
            {
                HeartAnim.SetBool("lowHP", false);
            }
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
