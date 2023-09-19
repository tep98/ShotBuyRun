using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public WavesManager WavesManagerController;
    public GameObject[] damageSounds;

    private Renderer PillagerSpriteRenderer;

    private void Start()
    {
        PillagerSpriteRenderer = GetComponent<Renderer>();
        WavesManagerController = GameObject.Find("WavesManager").GetComponent<WavesManager>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        int randSound = Random.Range(0, damageSounds.Length);
        Instantiate(damageSounds[randSound], transform.position, Quaternion.identity);
        Destroy(damageSounds[randSound]);

        PillagerSpriteRenderer.material.SetColor("_Color", new Color(200 / 255.0f, 183 / 255.0f, 183 / 255.0f));
        Invoke("SetDefaultColor", 0.2f);


        if (health <= 0)
        {
            
            Die();
        }
    }

    private void Die()
    {
        WavesManagerController.ExtendKillCounter();
        Destroy(gameObject);
    }

    private void SetDefaultColor()
    {
        PillagerSpriteRenderer.material.SetColor("_Color", Color.white);
    }
}
