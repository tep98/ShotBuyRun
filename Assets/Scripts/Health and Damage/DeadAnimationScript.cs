using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAnimationScript : MonoBehaviour
{
    private Health HPManager;
    public GameObject player;
    private Animator MCAnimator;

    private bool isLive = true;


    private void Start()
    {
        HPManager = player.GetComponent<Health>();
        MCAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if ((HPManager._hp <= 0) && isLive)
        {
            MCAnimator.SetTrigger("KillMC");
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            GameObject.FindGameObjectWithTag("Weapon").SetActive(false);
            GameObject.Find("StepSound").SetActive(false);
            isLive = false;
        }
    }

    public void KillPlayer()
    {
        HPManager.KillMC();
    }
}
