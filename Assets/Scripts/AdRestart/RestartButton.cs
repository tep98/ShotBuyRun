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
    }

    public void RelivePlayer()//функция, вызываемая в JS
    {
        health.RespawnMC();
    }
}
