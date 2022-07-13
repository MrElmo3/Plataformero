using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    
    private GameObject indicador;
    public GameObject bullet;

    private float minTime = 1.7f;
    private float maxTime = 6.3f;
    private float lastTimeBullet;
    private float randomNumer;

    private void Awake()
    {
        indicador = transform.GetChild(0).gameObject;
        
    }

    private void Start()
    {
        lastTimeBullet = Time.time;
        indicador.GetComponent<SpriteRenderer>().enabled = false;
    }
    
    void Update()
    {
        float randomNumer = Random.Range(minTime, maxTime);
        if(Time.time > lastTimeBullet + randomNumer){
            Shoot();
            lastTimeBullet = Time.time;
        }
    }

    private void Shoot(){
        GameObject p =Instantiate(bullet, indicador.transform.position, Quaternion.identity);
        p.GetComponent<Bullet>().setParent(transform.gameObject);
    }
}
