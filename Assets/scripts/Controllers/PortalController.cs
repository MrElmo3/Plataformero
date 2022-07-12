using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private GameObject[] portals;
    
    void Start()
    {
        portals = GameObject.FindGameObjectsWithTag("Portal");
    }

    void Update()
    {
        
    }
}
