using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{

    public bool playerVivo;
    public float life;

    public GameObject limite;

    private Rigidbody2D PlayerRigidBody;
    private Collider2D DieCollider;
    private Animator animator;
    private bool sended;

    void Start()
    {
        playerVivo = true;
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        DieCollider = GetComponent<BoxCollider2D>();
        life = 100;
        sended = false;
    }


    void Update()
    {
        animator.SetBool("vivo", playerVivo);
        if(!playerVivo){
            PlayerRigidBody.gravityScale = 0f;
            PlayerRigidBody.velocity = new Vector2(0,0);
        }
        if(life <=0){
            playerVivo = false;
        }

        if(!playerVivo && !sended){
            ScoreScript score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
            score.usingScore = false;
            score.SubirScore();
            sended = true;

            animator.SetBool("vivo", playerVivo);
            PlayerRigidBody.GetComponentInParent<Collider2D>().isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == DieCollider){
            playerVivo = false;
        }
    }

    public void destroyEnemy(){
        this.life += 10;
    }
}
