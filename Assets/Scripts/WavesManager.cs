using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float speedPercent;

   
    public float waveTimeBtwSpawns;
    public float waveMinTimeBtwSpawns;
    public float frequencyPercent;

    public int currentWave = 1;
    private float timer;
    public float waveTime;
    public float timeOutTime;

    public int killCount = 0;

    public Text WaveNotiText;
    public Text currentWaveUI;

    public GameObject Spawner;
    public GameObject Shop;
    private Animator ShopAnim;


    public Animator WaveNotiAnim;

    [SerializeField] string _en;
    [SerializeField] string _ru;

    private string currentValue;

    void Start()
    {
        timer = waveTime + timeOutTime;
        ShopAnim = Shop.GetComponent<Animator>();

        if (Language.Instance.currentLanguage == "en")
        {
            currentValue = _en;
        }
        else if (Language.Instance.currentLanguage == "ru")
        {
            currentValue = _ru;
        }
        else
        {
            currentValue = _en;
        }
        WaveNotiText.text = currentValue + " " + currentWave.ToString();
        currentWaveUI.text = currentValue + " " + currentWave.ToString();
    }

    void Update()
    {
        if (timer <= 0)
        {   
            Spawner.SetActive(false);
            if (killCount >= Spawner.GetComponent<Spawner>().countSpawns)
            {
                currentWave += 1;
                WaveNotiText.text = currentValue + " " + currentWave.ToString();
                currentWaveUI.text = currentValue + " " + currentWave.ToString();
                WaveNotiAnim.SetBool("ShowWaveNoti", true);
                Shop.SetActive(true);

                waveTimeBtwSpawns = waveTimeBtwSpawns / 100 * (100 - frequencyPercent);
                waveMinTimeBtwSpawns = waveMinTimeBtwSpawns / 100 * (100 - frequencyPercent);
                speed += (maxSpeed - speed)/100*speedPercent;

                timer = waveTime + timeOutTime;
                Invoke("SpawnerActive", timeOutTime);
            }
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
        ShopAnim.SetTrigger("TurnOff");
    }
}
