using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float _maxHP;

    [SerializeField]
    private UnityEvent Die;
    
    [SerializeField]
    private UnityEvent<float> HpChaged;
    [SerializeField]
    private UnityEvent<float> HpChagedPercent;

    public GameObject panel;
    public GameObject gameplayUI;
    public GameObject notiUI;
    public GameObject AdRestart;
    
    private WavesManager WavesManagerController;
    private int killStats;
    private int waveStats;
    public Text WavesStatistic;
    public Text KillStatistic;

    public AudioSource mainMusic;


    public float _hp;

    public float HP
    {
        get => _hp;
        set
        { 
            _hp = value;
            HpChaged?.Invoke(_hp);
            HpChagedPercent?.Invoke(_hp/_maxHP);
        }
    }

    private void Start()
    {
        Init();
        WavesManagerController = GameObject.Find("WavesManager").GetComponent<WavesManager>();
        killStats = WavesManagerController.killCount;
        waveStats = WavesManagerController.currentWave;
    }

    public void Init()
    {
        HP = _maxHP;
    }

    public void GetDamage(float damage)
    {
        HP-=damage;
    }

    public void AddHealth(float hp)
    {
        HP+=hp;
    } 
    public void KillMC()
    {
        Die?.Invoke();
        AdRestart.SetActive(false);
        panel.SetActive(true);
        gameplayUI.SetActive(false);
        notiUI.SetActive(false);
        gameObject.SetActive(false);

        mainMusic.pitch = 0.95f;

        killStats = WavesManagerController.killCount;
        waveStats = WavesManagerController.currentWave;
        KillStatistic.text = "Убийства: " + killStats.ToString();
        WavesStatistic.text = "Волн пройдено: " + (waveStats - 1).ToString();
    }
}
