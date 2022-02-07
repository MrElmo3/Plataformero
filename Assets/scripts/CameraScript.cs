using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public GameObject background;

    private Rigidbody2D Rigidbody2D;
    private GameObject firstBackground;

    //maximo y minimo de la camara

    private float maxRight = 50f;
    private float maxLeft = -1f;
    private int quantityBackgounds = 0;

    private void Start() {
        Rigidbody2D = player.GetComponent<Rigidbody2D>();
        Instantiate(background, transform.position + new Vector3(0.5f, 0.25f, -transform.position.z), Quaternion.identity, transform);
        quantityBackgounds++;
        firstBackground = transform.GetChild(0).gameObject;
    }
    
    void Update()
    {
         Vector3 position = transform.position;
        position.x = Mathf.Clamp(player.transform.position.x, maxLeft, maxRight);
        transform.position = position;

       if( (firstBackground.transform.position.x - position.x <= -0.5f)  && (quantityBackgounds < 2) ){
           createBackground();
       }

       else if( (firstBackground.transform.position.x  - position.x <= -3.34f ) ){
           destroyBackground();
       }
    }

    private void createBackground(){
        Instantiate(background, transform.position + new Vector3(3.325f, 0.275f, -transform.position.z), Quaternion.identity, transform);
        quantityBackgounds++;
    }

    private void destroyBackground(){
        firstBackground = transform.GetChild(1).gameObject;
        Destroy(transform.GetChild(0).gameObject);
        quantityBackgounds--;
    }
}
