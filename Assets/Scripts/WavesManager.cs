using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    public float speed;
    public GameObject Spawner;
    public Text currentWaveUI;
    public float waveTimeBtwSpawns;
    public float waveMinTimeBtwSpawns;
    private int currentWave = 1;
    private float timer;
    public float waveTime;
    public float timeOutTime;
    public float percent;


    void Start()
    {
        timer = waveTime + timeOutTime;
    }

    void Update()
    {
        if (timer <= 0)
        {
            currentWave += 1;
            currentWaveUI.text = currentWave.ToString();
            waveTimeBtwSpawns = waveTimeBtwSpawns/100*(100-percent);
            waveMinTimeBtwSpawns = waveMinTimeBtwSpawns/100*(100-percent);
            speed += 0.05f;
            timer = waveTime + timeOutTime;
            Spawner.SetActive(false);
            Invoke("SpawnerActive", timeOutTime);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void SpawnerActive()
    {
        Spawner.SetActive(true);
    }
}
