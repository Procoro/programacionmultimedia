using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject[] animalesPrefab;
    private float xposicion1 = 20f;
    private float xposicion2 = 20f;
    private float inicioGeneracion = 2.0f;
    private float retardoGeneracion = 1.5f;

    void Start()
    {
        InvokeRepeating("GenerarAleatorio", inicioGeneracion, retardoGeneracion);
    }

    void GenerarAleatorio()
    {
        int a = Random.Range(0, animalesPrefab.Length);
        Vector3 PosicionGenerator = new Vector3(Random.Range(-xposicion1, xposicion2), 0, 20);
        Instantiate(animalesPrefab[a], PosicionGenerator, animalesPrefab[a].transform.rotation);
    
    }
}

