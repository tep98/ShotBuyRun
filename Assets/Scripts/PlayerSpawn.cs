using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerSpawn : MonoBehaviour
{
    //функции для передачи в JS
    [DllImport("__Internal")]
    private static extern void StartAdBanner();

    public GameObject player;
    public GameObject playerMain;

    public AudioMixer audioMixer;

    public Animator DeadScreenAnimator;

    public void Start()
    {
        player.SetActive(false);
        StartAdBanner();
        Time.timeScale = 0;
    }

    public void OffPause()
    {
        Time.timeScale = 1;
    }

    public void Spawn()
    {
        audioMixer.SetFloat("Master", 0f);
        player.SetActive(true);
        playerMain.GetComponent<PlayerController>().enabled = true;
    }
}
