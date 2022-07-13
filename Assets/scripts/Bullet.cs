using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject parentShooting;
    protected float velocity;
    private Rigidbody2D PRigidBody2d;
    private Rigidbody2D Rigidbody2D;
    private float Pvelocity;
    
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        PRigidBody2d = parentShooting.GetComponent<Rigidbody2D>();
        Pvelocity = PRigidBody2d.velocity.x;

        if(!parentShooting.Equals(GameObject.FindGameObjectWithTag("Player"))){
            if(Pvelocity<0){
                Rigidbody2D.velocity = Vector2.left*velocity;
            }
            else{
                Rigidbody2D.velocity = Vector2.right*velocity;
            }
        }
        else{
            bool direction  = this.parentShooting.GetComponent<PlayerMovement>().getDirection();
            Rigidbody2D prb = this.parentShooting.GetComponent<Rigidbody2D>();
            if(!direction){
                Rigidbody2D.velocity = Vector2.left*velocity;
            }
            else{
                Rigidbody2D.velocity = Vector2.right*velocity;
            }
        }
        
    }
    
    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.Equals(parentShooting)){
            Destroy(gameObject);    
        }
        if(other.gameObject.tag == "Player" && parentShooting.tag =="Enemy"){
            other.gameObject.GetComponent<DieScript>().life-=20;
        }
    }
    public void setParent(GameObject parent){
        this.parentShooting = parent;
    }
}
