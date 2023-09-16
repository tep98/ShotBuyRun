using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;


    public GameObject bulletHitEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Instantiate(bulletHitEffect, new Vector3((transform.position.x + enemy.transform.position.x) / 2, (transform.position.y + enemy.transform.position.y) / 2, -1), Quaternion.identity);
            Destroy(gameObject);
        }
        Destroy(gameObject, 2);
    }
}
