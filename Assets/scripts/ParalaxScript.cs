using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScript : MonoBehaviour
{

    private float velocityMultiplicator = 0.7f;
    private GameObject camara;
    private Vector3 lastPosition;
    private float instantVelocity;

    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.FindWithTag("MainCamera");
        lastPosition = camara.transform.position;
    }

    private void FixedUpdate() {
        instantVelocity = (camara.transform.position.x - lastPosition.x)/Time.deltaTime;

        Vector3 position = transform.position;
        position.x += instantVelocity*(velocityMultiplicator-1f)*Time.deltaTime;
        transform.position = position;

        lastPosition = camara.transform.position;
    }
}
