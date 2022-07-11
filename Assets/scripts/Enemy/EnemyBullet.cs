using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
   private void Awake()
   {
        this.velocity = 2.5f;
   }
}
