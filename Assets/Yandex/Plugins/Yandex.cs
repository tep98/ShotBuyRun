using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    //функции для передачи в JS
    [DllImport("__Internal")]
    private static extern void RateGame();
    [DllImport("__Internal")]
    private static extern void PlayerAuth();
    [DllImport("__Internal")]
    private static extern void StartGame();

    public GameObject AuthButton;

    private void Start()
    {
        StartGame();
    }

    public void RateGameButton()
    {
        RateGame();
    }

    public void PlayerAuthButton()
    {
        PlayerAuth();
    }

    public void DisableButton()
    {
        AuthButton.SetActive(false);
    }
}
