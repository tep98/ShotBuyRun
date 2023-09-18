using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoint;

    private int rand;
    private int randPosition;
    private WavesManager timeController;
    public float newStartTimeBtwSpawns = 8;
    public float timeBtwSpawns;
    public float minTimeBtwSpawns;

    void Start()
    {
        timeBtwSpawns = newStartTimeBtwSpawns;
    }

    void Update()
    {
        timeController = GameObject.Find("WavesManager").GetComponent<WavesManager>();
        newStartTimeBtwSpawns = timeController.startTimeBtwSpawns; 

        if(timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, enemy.Length);
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemy[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = newStartTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}