using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) //Key Handler
        {
            Shoot();
        }
    }

    private void Shoot() //Shooting Logic
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
