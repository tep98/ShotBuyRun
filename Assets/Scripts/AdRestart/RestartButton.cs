using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject player;
    private Health health;

    public AudioSource mainMusic;
    private float musicVolume;

    [DllImport("__Internal")]
    private static extern void AdRelive();

    private void Start()
    {
        health = player.GetComponent<Health>();
        transform.parent = null;
        musicVolume = mainMusic.volume;
    }

    public void ShowAdButton() //функция для кнопки
    {
        AdRelive();
        Time.timeScale = 0;
        mainMusic.volume = 0f;
    }

    public void RelivePlayer()//функция, вызываемая в JS
    {
        Time.timeScale = 1;
        health.RespawnMC();
        mainMusic.volume = musicVolume;
    }
}
