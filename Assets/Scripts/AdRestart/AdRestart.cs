using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdRestart : MonoBehaviour
{
    private Health HPManager;
    public GameObject player;


    public Button continueButton;

	public void Start () {
        HPManager = player.GetComponent<Health>();
		continueButton.onClick.AddListener(TaskOnClick);
	}
    public void TaskOnClick()
    {       
        HPManager.KillMC();
    }
}
