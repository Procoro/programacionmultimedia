using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGenerador : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject prefabObstaculo;
    private Vector3 posicionGenerador = new Vector3(25, 0, 0);
    private float tiempoRetraso = 2;
    private float intervaloRepeticion;
    private ControlJugador scriptControlJugador;
    void Start()
    {
        scriptControlJugador = GameObject.Find("Jugador").GetComponent<ControlJugador>();
        Invoke("GenerarObstaculo", tiempoRetraso);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerarObstaculo() {
        if (scriptControlJugador.gameOver == false) {
            intervaloRepeticion = Random.Range(1.5f, 3);
            //esto lo podemos hacer usando !scriptControlJugador.gameOver
            Instantiate(prefabObstaculo, posicionGenerador, prefabObstaculo.transform.rotation);
            Invoke("GenerarObstaculo", intervaloRepeticion);
        }

       

    }
}
