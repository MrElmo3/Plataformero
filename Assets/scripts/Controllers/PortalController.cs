using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private GameObject[] portals;
    private float velocidadInicial = 10f;
    private float multiplicador = 50f;
    private float velocidadGeneracion;
    private float ultimaGeneracion;

    public GameObject enemy;
    public GameObject parent;

    void Start()
    {
        portals = GameObject.FindGameObjectsWithTag("Portal");
        ultimaGeneracion = 0f;
        velocidadGeneracion = velocidadInicial;
    }

    void Update()
    {
        if(Time.time > ultimaGeneracion + velocidadGeneracion){
            velocidadGeneracion = multiplicador/(Time.time + multiplicador/velocidadInicial);
            int index = Random.value < 0.5? 0: 1;
            generarEnemigo(index);
            ultimaGeneracion = Time.time;
        }
    }

    private void generarEnemigo(int index){
        GameObject p = Instantiate(enemy, portals[index].transform.position, Quaternion.identity);
        p.transform.SetParent(parent.transform);
    }
}
