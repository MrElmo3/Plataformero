using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerVelocity; 
    public float jumpForce;
    

    //private bool isGrounded;
    private bool isGorund;
    private float horizontalAxis;
    private float salto;


    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        salto = Input.GetAxisRaw("Jump");
        horizontalAxis = Input.GetAxisRaw("Horizontal");

        Animator.SetBool("running", horizontalAxis != 0.0f);

        
        if(Input.GetKeyDown(KeyCode.W) && isGorund){
            jump();
        }

        Debug.DrawRay(transform.position, Vector3.down *0.1f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            isGorund = true;
        }
        else isGorund = false;

    }

    void jump(){
        Rigidbody2D.AddForce(Vector2.up*jumpForce);
    }

    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(horizontalAxis*playerVelocity, Rigidbody2D.velocity.y);
    }
}