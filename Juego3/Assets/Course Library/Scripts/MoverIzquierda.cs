using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverIzquierda : MonoBehaviour
{
    // Start is called before the first frame update
    private float velocidad = 15f;
    private float limiteIzquierdo = -15;
    private ControlJugador ScriptControlJugador;
    void Start()
    {
       ScriptControlJugador = GameObject.Find("Jugador").GetComponent<ControlJugador>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ScriptControlJugador.gameOver==false) { 
         transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
        if (transform.position.x < limiteIzquierdo &&gameObject.CompareTag("Obstaculo")) {
            Destroy(gameObject);
        }


    }
}
