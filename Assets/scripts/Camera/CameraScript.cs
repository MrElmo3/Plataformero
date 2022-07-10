using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D Rigidbody2D;

    //maximo y minimo de la camara

    private float maxRight = 2.3f;
    private float maxLeft = -3.7f;

    private void Start() {
        Rigidbody2D = player.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(player.transform.position.x, maxLeft, maxRight);
        transform.position = position;

    }
}
