using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{
    // Start is called before the first frame update
    public float desplazamientoHorizontal;
    public float velocidad = 10f;
    public GameObject ProyectilPrefab;
    void Start()
    {
        Debug.Log("estas comenzando el juego");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ahora vamos a realizar instancias o copias del prefab que hemos creado
            //transformm position accedemos a la misma
            //posicion del jugador. con proyectilprefb.transror.rotation le decimos que no queremos ninguna rotacion
            Instantiate(ProyectilPrefab, transform.position,
                ProyectilPrefab.transform.rotation);

        }


        if (transform.position.x < -20)
        {
            transform.position = new Vector3(-20, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 20)
        {
            transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }

        desplazamientoHorizontal = Input.GetAxis("Horizontal");
        //Mover al jugarod horizontalmente
        transform.Translate(Vector3.right * desplazamientoHorizontal * Time.deltaTime * velocidad);

    }
}

