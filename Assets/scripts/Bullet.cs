using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D Rigidbody2D;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Rigidbody2D.velocity = Vector2.right * velocity;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
        
    }
}
