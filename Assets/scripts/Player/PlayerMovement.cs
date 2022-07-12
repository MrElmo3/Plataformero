using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerVelocity; 
    public float jumpForce;
    
    private bool isGorund;
    private bool direction; // false <- true ->
    private float horizontalAxis;
    private float salto;

    public Rigidbody2D Rigidbody2D;
    private Animator Animator;
    
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        salto = Input.GetAxisRaw("Vertical");
        horizontalAxis = Input.GetAxisRaw("Horizontal");

        Animator.SetBool("running", horizontalAxis != 0.0f);

        if(horizontalAxis < 0 || !direction){
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else{
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if(salto > 0 && isGorund){
            jump();
        }

        Debug.DrawRay(transform.position, Vector3.down *0.1f, Color.red);
        //if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
        //    isGorund = true;
        //}
        //else isGorund = false;

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor")){
            isGorund = true;
        }
    }

    private void jump(){
        Rigidbody2D.AddForce(Vector2.up*jumpForce);
        isGorund = false;
    }

    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(horizontalAxis*playerVelocity, Rigidbody2D.velocity.y);
        if(Rigidbody2D.velocity.x > 0){
            direction = true;
        }
        else if(Rigidbody2D.velocity.x < 0){
            direction = false;
        }
    }

    public bool getDirection(){
        return this.direction;
    }
}
