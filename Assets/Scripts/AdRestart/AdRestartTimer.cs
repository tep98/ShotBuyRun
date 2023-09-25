using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdRestartTimer : MonoBehaviour
{
    private float StartTimeBtwSpawns = 5;
    private int leftSec = 5;
    private float timeBtwSpawns;


    private Health HPManager;
    public GameObject player;
    public Text Timer;

    void Start()
    {
        HPManager = player.GetComponent<Health>();
        timeBtwSpawns = StartTimeBtwSpawns;
        Timer.text = leftSec.ToString();
    }

    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            timeBtwSpawns = StartTimeBtwSpawns;
            HPManager.KillMC();    
        }
        else
        {
            leftSec = (int)timeBtwSpawns + 1;
            Timer.text = leftSec.ToString();
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    public void ResetTimer()
    {
        timeBtwSpawns = StartTimeBtwSpawns;
    }
}
