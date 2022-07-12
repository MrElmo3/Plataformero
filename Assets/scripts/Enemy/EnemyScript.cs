using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject gemstone;
    public Collider2D gemstoneCollider;
    private float velocity = 0.40f;
    private Rigidbody2D Rigidbody2D;
    private bool vivo;

    void Start()
    {
        gemstone = GameObject.FindGameObjectWithTag("Cristal");
        Rigidbody2D = GetComponent<Rigidbody2D>();
        gemstoneCollider = gemstone.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vector = gemstone.transform.position - transform.position;
        var distance = vector.magnitude;
        var verctorNormalized = vector/distance;
        Debug.Log(verctorNormalized.x);
        if(verctorNormalized.x > 0){
            transform .rotation = new Quaternion(0, 180, 0, 0);
        }
        else{
             transform .rotation = new Quaternion(0, 0, 0, 0);
        }
        Rigidbody2D.velocity = new Vector2(verctorNormalized.x, verctorNormalized.y) * velocity;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == gemstoneCollider){
            vivo = false;
            Destroy(gameObject);
        }
    }
}
