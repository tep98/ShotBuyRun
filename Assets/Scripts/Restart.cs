using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Animator DeadScreenAnimator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {        
            DeadScreenAnimator.SetTrigger("CloseDeadScreen");
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
