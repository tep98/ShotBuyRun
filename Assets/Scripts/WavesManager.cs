using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public float speed = 3;
    public float startTimeBtwSpawns = 8;
    private int currentWave;
    private float timer;
    public float timeBtwTimer = 60;


    void Start()
    {
        timer = timeBtwTimer;
    }

    void Update()
    {
        if (timer <= 0)
        {
            currentWave += 1;
            startTimeBtwSpawns -= 0.25f;
            speed += 0.05f;
            timer = timeBtwTimer;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
