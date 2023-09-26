using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject player;
    private Health health;

    [DllImport("__Internal")]
    private static extern void AdRelive();

    private void Start()
    {
        health = player.GetComponent<Health>();
        transform.parent = null;
    }

    public void ShowAdButton() //функция для кнопки
    {
        AdRelive();
        Time.timeScale = 0;
    }

    public void RelivePlayer()//функция, вызываемая в JS
    {
        Time.timeScale = 1;
        health.RespawnMC();
    }
}
