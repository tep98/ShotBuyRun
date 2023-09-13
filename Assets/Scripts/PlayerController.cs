using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private Vector2 moveVector;

    private bool facingLeft = true;
    private Animator anim;
    public GameObject animationObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = animationObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);

        if(facingLeft && moveVector.x > 0)
        {
            TurnPlayer();
        }
        else if(!facingLeft && moveVector.x < 0)
        {
            TurnPlayer();
        }

        if(moveVector.x != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
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
