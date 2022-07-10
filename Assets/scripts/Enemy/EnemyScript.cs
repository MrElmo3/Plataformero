using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject gemstone;
    private float velocity = 1.0f;
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        gemstone = GameObject.FindGameObjectWithTag("Cristal");
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vector = gemstone.transform.position - transform.position;
        var distance = vector.magnitude;
        var verctorNormalized = vector/distance;
        Rigidbody2D.velocity = new Vector2(verctorNormalized.x, verctorNormalized.y) * velocity;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
