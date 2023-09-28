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

    public void Start()
    {
        StartAdBanner();
        Time.timeScale = 0;
        player.SetActive(false);
    }

    public void OffPause()
    {
        Time.timeScale = 1;
    }

    public void Spawn()
    {
        player.SetActive(true);
        playerMain.GetComponent<PlayerController>().enabled = true;
    }
}
