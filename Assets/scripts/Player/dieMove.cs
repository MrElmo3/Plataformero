using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieMove : MonoBehaviour
{
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Player.transform.position.x, transform.position.y);
    }
}
