using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public GameObject playerMain;

    private void Start()
    {
        player.SetActive(false);
    }
    public void Spawn()
    {
        player.SetActive(true);
        playerMain.GetComponent<PlayerController>().enabled = true;
    }
}
