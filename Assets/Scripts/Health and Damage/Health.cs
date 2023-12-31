using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Audio;

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
    public Text KillRecordUI;
    public Text WavesRecordUI;

    public AudioMixer audioMixer;

    public GameObject animatedPlayer;
    private DeadAnimationScript DeadAnimScript;

    public GameObject timer;

    [SerializeField] string _enKills;
    [SerializeField] string _ruKills; 
    [SerializeField] string _enWaves;
    [SerializeField] string _ruWaves;
    [SerializeField] string _enRecordKills;
    [SerializeField] string _ruRecordKills;
    [SerializeField] string _enRecordWaves;
    [SerializeField] string _ruRecordWaves;
    private string currentValueKills;
    private string currentValueWaves;
    private string currentValueRecordKills;
    private string currentValueRecordWaves;
    private int KillRecord = 0;
    private int WavesRecord = 0;

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
            currentValueRecordKills = _enRecordKills;
            currentValueRecordWaves = _enRecordWaves;
        }
        else if (Language.Instance.currentLanguage == "ru")
        {
            currentValueKills = _ruKills;
            currentValueWaves = _ruWaves;
            currentValueRecordKills = _ruRecordKills;
            currentValueRecordWaves = _ruRecordWaves;
        }
        else
        {
            currentValueKills = _enKills;
            currentValueWaves = _enWaves;
            currentValueRecordKills = _enRecordKills;
            currentValueRecordWaves = _enRecordWaves;
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
        audioMixer.SetFloat("Master", -80f);
        gameObject.SetActive(false);
        AdRestart.SetActive(false);
        panel.SetActive(true);
        gameplayUI.SetActive(false);
        notiUI.SetActive(false);

        DeathAdBanner();        

        Time.timeScale = 0;

        killStats = WavesManagerController.killCount;
        waveStats = WavesManagerController.currentWave;
        KillStatistic.text = currentValueKills + ": " + killStats.ToString();
        WavesStatistic.text = currentValueWaves + ": " + (waveStats - 1).ToString();

        KillRecord = killStats;
        WavesRecord = waveStats;

        if (KillRecord>Progress.Instance.PlayerInfo.Kills)
        {
            Progress.Instance.PlayerInfo.Kills = KillRecord;
        }
        if (WavesRecord>Progress.Instance.PlayerInfo.Waves)
        {
            Progress.Instance.PlayerInfo.Waves = WavesRecord;
        }

        KillRecordUI.text = currentValueRecordKills + ": " + Progress.Instance.PlayerInfo.Kills.ToString();
        WavesRecordUI.text = currentValueRecordWaves + ": " + (Progress.Instance.PlayerInfo.Waves - 1).ToString();

        Progress.Instance.Save();
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
