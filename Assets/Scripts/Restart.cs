using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Animator DeadScreenAnimator;
    public Button restartButton;

    public GameObject bullet;
    private Bullet bulletScript;


    public void Start () {
		restartButton.onClick.AddListener(TaskOnClick);
        bulletScript = bullet.GetComponent<Bullet>();
    }
    public void TaskOnClick()
    {       
        DeadScreenAnimator.SetTrigger("CloseDeadScreen");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        bulletScript.SetDefaultDamage();
    }
}
