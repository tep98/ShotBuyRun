using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    public float speed;
    public GameObject Spawner;
    public float waveTimeBtwSpawns;
    public float waveMinTimeBtwSpawns;
    private int currentWave = 1;
    private float timer;
    public float waveTime;
    public float timeOutTime;
    public float percent;
    public int killCount = 0;

    public Text WaveNotiText;
    public Text currentWaveUI;

    public Animator WaveNotiAnim;

    void Start()
    {
        timer = waveTime + timeOutTime;
    }

    void Update()
    {
        if (timer <= 0)
        {
            currentWave += 1;
            WaveNotiText.text = "Волна " + currentWave.ToString();
            currentWaveUI.text = "Волна " + currentWave.ToString();
            waveTimeBtwSpawns = waveTimeBtwSpawns/100*(100-percent);
            waveMinTimeBtwSpawns = waveMinTimeBtwSpawns/100*(100-percent);
            speed += 0.05f;
            timer = waveTime + timeOutTime;
            Spawner.SetActive(false);
            WaveNotiAnim.SetBool("ShowWaveNoti", true);
            Invoke("SpawnerActive", timeOutTime);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void ExtendKillCounter()
    {
        killCount++;
    }

    private void SpawnerActive()
    {
        Spawner.SetActive(true);
        WaveNotiAnim.SetBool("ShowWaveNoti", false);
    }
}
