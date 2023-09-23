using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameplayUI;
    public GameObject notiUI;
    public GameObject AdRestart;
    public GameObject player;

    [DllImport("_Internal")]
    private static extern void AdRelive(bool value);

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowAdButton()
    {
        AdRelive(true);
    }

    public void RelivePlayer()
    {
        AdRestart.SetActive(false);
        panel.SetActive(false);
        gameplayUI.SetActive(true);
        notiUI.SetActive(true);
        player.SetActive(true);
    }
}
