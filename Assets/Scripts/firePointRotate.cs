using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePointRotate : MonoBehaviour
{
    private Gun gunScript;
    private bool gunTurnLeft;
    private bool isRotateLeft = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gunScript = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Gun>();
        gunTurnLeft = gunScript.gunTurnLeft;
        if (gunTurnLeft && !isRotateLeft)
        {
            transform.Rotate(0f,180f,0f);
            isRotateLeft = !isRotateLeft;
        }
        else if (!gunTurnLeft && isRotateLeft)
        {
            transform.Rotate(0f,-180f,0f);
            isRotateLeft = !isRotateLeft;
        }
    }
}
