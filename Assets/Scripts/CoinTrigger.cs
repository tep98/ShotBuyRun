using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    private CoinManager coinManager;

    private void Start()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            coinManager.PlusCoins();
        }
    }
}
