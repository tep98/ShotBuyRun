using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public WavesManager WavesManagerController;

    private Renderer PillagerSpriteRenderer;

    //Objects
    public GameObject Coin;
    private TextMesh damageText;

    //Переменные для критического урона
    public float criticalHitChance = 0.1f; // Шанс крита (0.1f = 10%)
    public int criticalHitMultiplier = 2;  // Множитель крита


    private void Start()
    {
        PillagerSpriteRenderer = GetComponent<Renderer>();
        WavesManagerController = GameObject.Find("WavesManager").GetComponent<WavesManager>();
    }

    public void TakeDamage(int damage)
    {
        int endDamage = damage;
        float randomValue = Random.value;

        if (randomValue <= criticalHitChance)
        {
            endDamage *= criticalHitMultiplier;
            Debug.Log("Critical Damage!"); //временно, для проверки работоспособности
        }

        health -= endDamage;
        
        PillagerSpriteRenderer.material.SetColor("_Color", new Color(200 / 255.0f, 183 / 255.0f, 183 / 255.0f));
        Invoke("SetDefaultColor", 0.2f);

        GetComponent<AudioSource>().Play();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        WavesManagerController.ExtendKillCounter();
        Instantiate(Coin, new Vector3(transform.position.x, transform.position.y, 4), Quaternion.identity);
        Destroy(gameObject);
    }

    private void SetDefaultColor()
    {
        PillagerSpriteRenderer.material.SetColor("_Color", Color.white);
    }
}