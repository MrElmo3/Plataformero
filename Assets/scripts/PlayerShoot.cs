using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject indicador;
    public GameObject bullet;

    private float lastTimeBullet;
   private void Awake() {
       indicador.GetComponent<SpriteRenderer>().enabled = false;
       lastTimeBullet = Time.time;
   }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time > lastTimeBullet + 0.25f){
            Shoot();
            lastTimeBullet = Time.time;
        }
    }
    private void Shoot(){
        Instantiate(bullet, indicador.transform.position, Quaternion.identity);
    }
}
