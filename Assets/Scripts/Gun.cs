using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    private PlayerController Controller;
    public bool gunTurnLeft = true;

    public Transform target;


    private void Update()
    {
        Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        offset = Controller.facingLeft ? 180 : 0;

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset);

        if ((-70 < rotationZ && rotationZ < 70 || rotationZ < 70 && rotationZ > -70) && gunTurnLeft)
        {
            GeneralTurnGun();
        }
        else if ((-110 > rotationZ || rotationZ > 110) && !gunTurnLeft)
        {
            GeneralTurnGun();
        }
    }

    public void GeneralTurnGun()
    {
        gunTurnLeft = !gunTurnLeft;
        Controller.TurnPlayer();

    }

}
