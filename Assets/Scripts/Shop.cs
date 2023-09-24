using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject bullet;
    public GameObject health;
    public GameObject Gold;

    private Bullet bulletScript;
    private Health healthScript;
    private CoinManager Coin;

    public int healthCost;
    public int damageCost;

    private void Start()
    {
        bulletScript = bullet.GetComponent<Bullet>();
        healthScript = health.GetComponent<Health>();
        Coin = Gold.GetComponent<CoinManager>();
    }
    
    public void AddDamage(int AddedDamage)
    {
        
        if (Coin.coins >= damageCost)
        {
            bulletScript.AddDamage(AddedDamage);
            Coin.MinusCoins(damageCost);
        }
    }

    public void AddHealth(float hp)
    {
        if (healthScript._maxHP > healthScript._hp)
        {
            Debug.Log(healthCost);
            Debug.Log(Coin.coins);

            if (Coin.coins >= healthCost)
            {
                healthScript.AddHealth(hp);
                Coin.MinusCoins(healthCost);
            }
            
        }
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }


}
