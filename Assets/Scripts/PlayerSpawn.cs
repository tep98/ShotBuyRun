using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    //функции для передачи в JS
    [DllImport("__Internal")]
    private static extern void StartAdBanner();

    public GameObject player;
    public GameObject playerMain;

    public AudioSource mainMusic;
    private float musicVolume;

    public void Start()
    {
        player.SetActive(false);
        StartAdBanner();
        Time.timeScale = 0;
        musicVolume = mainMusic.volume;
        mainMusic.volume = 0f;
    }

    public void OffPause()
    {
        Time.timeScale = 1;
        mainMusic.volume = musicVolume;
    }

    public void Spawn()
    {
        player.SetActive(true);
        playerMain.GetComponent<PlayerController>().enabled = true;
    }
}
