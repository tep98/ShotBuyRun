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

    private void Start()
    {
        playerSpriteRenderer = playerSprite.GetComponent<Renderer>();
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.TryGetComponent<AttackSystem>(out var attacksystem))
        {
            DamageGot?.Invoke(attacksystem.Damage);
            playerSpriteRenderer.material.SetColor("_Color", new Color(200/255.0f, 83/255.0f, 83/255.0f));
            Invoke("SetDefaultColor", 0.2f);

            Instantiate(takeDamageSound, transform.position, Quaternion.identity);
            Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
        }
    }

    private void SetDefaultColor()
    {
        playerSpriteRenderer.material.SetColor("_Color", Color.white);
    }
}
