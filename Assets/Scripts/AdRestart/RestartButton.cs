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

    [DllImport("__Internal")]
    private static extern void AdRelive();

    public void ShowAdButton() //функция для кнопки
    {
        AdRelive();
    }

    public void RelivePlayer()//функция, вызываемая в JS
    {
        AdRestart.SetActive(false);
        panel.SetActive(false);
        gameplayUI.SetActive(true);
        notiUI.SetActive(true);
        player.SetActive(true);
    }
}
