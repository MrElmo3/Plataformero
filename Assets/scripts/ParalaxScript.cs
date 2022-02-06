using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScript : MonoBehaviour
{

    public float backgroundVelocity;

    private GameObject player;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        lastPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(lastPosition.x != player.transform.position.x){
            moveBackgound();
        }
    }

    private void moveBackgound(){
        
    }
}
