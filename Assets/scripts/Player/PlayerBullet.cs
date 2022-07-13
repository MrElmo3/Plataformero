using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{

    private void Awake()
    {
        this.velocity = 3.5f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);
            parentShooting.GetComponent<DieScript>().destroyEnemy();
        }
        Destroy(gameObject);
    }

}
