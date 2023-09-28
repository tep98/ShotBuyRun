using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //функции для передачи в JS
    [DllImport("__Internal")]
    private static extern void DeathAdBanner();

    [SerializeField]
    public float _maxHP;
    
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

    public GameObject animatedPlayer;
    private DeadAnimationScript DeadAnimScript;

    public GameObject timer;

    [SerializeField] string _enKills;
    [SerializeField] string _ruKills; 
    [SerializeField] string _enWaves;
    [SerializeField] string _ruWaves;
    private string currentValueKills;
    private string currentValueWaves;

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
        DeadAnimScript = animatedPlayer.GetComponent<DeadAnimationScript>();
        Init();
        WavesManagerController = GameObject.Find("WavesManager").GetComponent<WavesManager>();
        killStats = WavesManagerController.killCount;
        waveStats = WavesManagerController.currentWave;

        if (Language.Instance.currentLanguage == "en")
        {
            currentValueKills = _enKills;
            currentValueWaves = _enWaves;
        }
        else if (Language.Instance.currentLanguage == "ru")
        {
            currentValueKills = _ruKills;
            currentValueWaves = _ruWaves;
        }
        else
        {
            currentValueKills = _enKills;
            currentValueWaves = _enWaves;
        }
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
        gameObject.SetActive(false);
        AdRestart.SetActive(false);
        panel.SetActive(true);
        gameplayUI.SetActive(false);
        notiUI.SetActive(false);

        mainMusic.pitch = 0.95f;

        DeathAdBanner();
        mainMusic.volume = 0f;

        Time.timeScale = 0;

        killStats = WavesManagerController.killCount;
        waveStats = WavesManagerController.currentWave;
        KillStatistic.text = currentValueKills + ": " + killStats.ToString();
        WavesStatistic.text = currentValueWaves + ": " + (waveStats - 1).ToString();
    }

    public void RespawnMC()
    {
        HP = _maxHP;
        gameObject.SetActive(true);
        AdRestart.SetActive(false);
        panel.SetActive(false);
        gameplayUI.SetActive(true);
        notiUI.SetActive(true);
        DeadAnimScript.Respawn();
        timer.GetComponent<AdRestartTimer>().ResetTimer();
    }
}
