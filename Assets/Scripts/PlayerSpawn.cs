using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject playerMain;

    private Health health;
    private DeadAnimationScript deadanim;

    private void Start()
    {
        health = player.GetComponent<Health>();
        deadanim = player.GetComponent<DeadAnimationScript>();
        deadanim.KillPlayer();
        health.FirstSpawnMC();
        player.SetActive(false);
    }
    public void Spawn()
    {
        player.SetActive(true);
        playerMain.GetComponent<PlayerController>().enabled = true;
    }
}
