using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected GameObject parentShooting;
    protected float velocity;
    private Rigidbody2D PRigidBody2d;
    private Rigidbody2D Rigidbody2D;
    private float Pvelocity;
    
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        PRigidBody2d = parentShooting.GetComponent<Rigidbody2D>();
        Pvelocity = PRigidBody2d.velocity.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Pvelocity<0){
            Rigidbody2D.velocity = Vector2.left*velocity;
        }
        else{
            Rigidbody2D.velocity = Vector2.right*velocity;
        }
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
    public void setParent(GameObject parent){
        this.parentShooting = parent;
    }
}
