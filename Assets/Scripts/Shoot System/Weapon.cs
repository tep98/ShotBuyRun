using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    
    public AudioSource ShootSound;
    public ParticleSystem ShootParticles;

    public Animator gunAnim;

    private void Start()
    {
        gunAnim = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) //Key Handler
        {
            gunAnim.SetTrigger("revolverShoot");
            Shoot();
        }
    }

    private void Shoot() //Shooting Logic
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        ShootSound.Play();
        ShootParticles.Play();
    }
}
