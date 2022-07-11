using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{

    public bool playerVivo;

    public GameObject limite;

    private Rigidbody2D PlayerRigidBody;
    private Collider2D DieCollider;
    private Animator animator;

    void Start()
    {
        playerVivo = true;
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        DieCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        animator.SetBool("vivo", playerVivo);
        
        if(!playerVivo){
            PlayerRigidBody.gravityScale = 0f;
            PlayerRigidBody.velocity = new Vector2(0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == DieCollider){
            Debug.Log($"hit!");
            playerVivo = false;
        }
    }
}
