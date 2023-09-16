using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public float lifetime = 0;
    public void Start()
    {
        Destroy(gameObject, lifetime);      
    }
}
