using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private Vector2 moveVector;

    public bool facingLeft = true;
    private Animator anim;
    public GameObject animationObject;
    public bool playerIsRunning = false;

    private Gun GunManager;
    private bool gunTurnLeft;

    public AudioSource step;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = animationObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        GunManager = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Gun>();
        gunTurnLeft = GunManager.gunTurnLeft;

        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);

        if(facingLeft && moveVector.x > 0 && !gunTurnLeft)
        {
            TurnPlayer();
        }
        else if(!facingLeft && moveVector.x < 0 && gunTurnLeft)
        {
            TurnPlayer();
        }

        if(moveVector.x != 0 || moveVector.y != 0)
        {
            anim.SetBool("isRunning", true);
            playerIsRunning = true;
        }
        else
        {
            anim.SetBool("isRunning", false);
            playerIsRunning = false;
            step.Play();
        }
    }

    public void TurnPlayer()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
