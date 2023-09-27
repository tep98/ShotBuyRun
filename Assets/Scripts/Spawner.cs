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
    public float newStartTimeBtwSpawns;
    public float timeBtwSpawns;
    public float newMinStartTimeBtwSpawns;

    public int countSpawns = 0;

    private void Start()
    {
        timeController = GameObject.Find("WavesManager").GetComponent<WavesManager>();
        newMinStartTimeBtwSpawns = timeController.waveMinTimeBtwSpawns;
    }

    private void OnEnable()
    {
        timeBtwSpawns = newStartTimeBtwSpawns;
        newStartTimeBtwSpawns = timeController.waveTimeBtwSpawns;
        newMinStartTimeBtwSpawns = timeController.waveMinTimeBtwSpawns; 
    }

    void Update()
    {
        timeController = GameObject.Find("WavesManager").GetComponent<WavesManager>();

        if(timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, enemy.Length);
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemy[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            if(newStartTimeBtwSpawns >= newMinStartTimeBtwSpawns)
            {
                newStartTimeBtwSpawns -= 0.25f;
            }
            timeBtwSpawns = newStartTimeBtwSpawns;

            countSpawns++;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}