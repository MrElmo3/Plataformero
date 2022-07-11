using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject indicador;
    public GameObject bullet;
    public DieScript script;

    private float lastTimeBullet;
    private void Awake() {
       indicador.GetComponent<SpriteRenderer>().enabled = false;
       lastTimeBullet = Time.time;
   }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time > lastTimeBullet + 0.30f && script.playerVivo){
            Shoot();
            lastTimeBullet = Time.time;
        }
    }
    private void Shoot(){
        GameObject p = Instantiate(bullet, indicador.transform.position, Quaternion.identity);
        p.GetComponent<Bullet>().setParent(transform.gameObject);
    }
}
