using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3;
    public Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); 
        }
}
