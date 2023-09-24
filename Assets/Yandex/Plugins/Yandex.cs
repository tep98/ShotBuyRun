using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    //функции для передачи в JS
    [DllImport("_Internal")]
    private static extern void RateGame();

    public void RateGameButton()
    {
        RateGame();
    }
}
