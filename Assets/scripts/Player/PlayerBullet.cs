using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{

    private void Awake()
    {
        this.parentShooting = GameObject.FindGameObjectWithTag("Player"); 
        this.velocity = 3.5f;
    }

}
