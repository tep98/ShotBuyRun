using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAnimationScript : MonoBehaviour
{
    private Health HPManager;
    public GameObject player;
    private PlayerController playerMove;
    private Animator MCAnimator;

    public GameObject weapon;

    public bool isLive = true;

    public GameObject wavesManager;
    public GameObject spawner;
    public GameObject AdRestart;

    public GameObject stepSound;

    private GameObject[] enemy;

    private void Start()
    {
        HPManager = player.GetComponent<Health>();
        MCAnimator = GetComponent<Animator>();
        playerMove = player.GetComponent<PlayerController>();
    }
    private void Update()
    {
        if ((HPManager._hp <= 0) && isLive)
        {
            isLive = false;
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            MCAnimator.SetTrigger("KillMC");
            weapon.SetActive(false);
            stepSound.SetActive(false);
            wavesManager.SetActive(false);
            spawner.SetActive(false);
            playerMove.enabled = false;

            foreach (GameObject one in enemy)
            {
                Destroy(one);
            }
        }
    }

    public void ShowAdRestart()
    {
        AdRestart.SetActive(true);
    }

    public void Respawn()
    {
        isLive = true;
        wavesManager.SetActive(true);
        spawner.SetActive(true);
        MCAnimator.SetTrigger("Respawn");
        stepSound.SetActive(true);
        weapon.SetActive(true);
        playerMove.enabled = true;
        enemy = null;
    }
}
