using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coins = 0;

    public Text coinsCounter;

    public Animator CoinUiAnim;

    public void PlusCoins()
    {
        coins++;
        SetCoinsCounter();
        CoinUiAnim.SetTrigger("CoinPlus");
    }

    public void MinusCoins(int value)
    {
        coins -= value;
        SetCoinsCounter();
        CoinUiAnim.SetTrigger("CoinMinus");
    }

    public void SetCoinsCounter()
    {
        coinsCounter.text = coins.ToString();
    }
}
