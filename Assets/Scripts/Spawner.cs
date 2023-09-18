using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoint;

    private int rand;
    private int randPosition;
    public float startTimeBtwSpawns;
    public float timeBtwSpawns;
    public float minTimeBtwSpawns;
    public float speed = 3;

    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, enemy.Length);
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemy[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            if (startTimeBtwSpawns >= minTimeBtwSpawns){
                startTimeBtwSpawns -= 0.25f;
                speed += 0.05f;
            }
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}