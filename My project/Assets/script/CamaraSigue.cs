using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Jugador;
    public int x, y, z;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Jugador.transform.position+new Vector3(x,y,z);
    }
}
