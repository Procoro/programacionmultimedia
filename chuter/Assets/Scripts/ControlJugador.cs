using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    // Declaración de variables públicas para ajustar desde el inspector de Unity.
    public float sensibilidadRaton = 120.0f; // Sensibilidad del ratón para la rotación.
    public float velocidad = 10.0f; // Velocidad de movimiento del jugador.
    public float distanciaDisparo = 50; // Distancia máxima para disparar.
    public float fuerzaDisparo = 15; // Fuerza del disparo.

    Camera camara; // Referencia a la cámara del jugador.
    public float rotacionCabeceo; // Ángulo de rotación vertical de la cámara.

    Rigidbody rbJugador; // Componente Rigidbody para mejorar el comportamiento de colisión.

    void Start()
    {
        // Obtener la cámara del objeto actual y la configuración inicial.
        camara = GetComponentInChildren<Camera>();
        rotacionCabeceo = camara.transform.rotation.x;
        rbJugador = GetComponent<Rigidbody>();

        // Ocultar el cursor del ratón y mantenerlo bloqueado en el centro de la pantalla.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Llamar a las funciones para manejar la rotación, el movimiento y el disparo del jugador.
        mirar();
        mover();
        if (Input.GetButton("Disparo"))
        {
            disparar();
        }
    }

    void mover()
    {
        // Capturar la entrada del jugador para moverse lateralmente y hacia adelante.
        float moviLateral = Input.GetAxis("Horizontal");
        float moviAvance = Input.GetAxis("Vertical");

        // Obtener la dirección de movimiento con respecto a la cámara.
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 desplazamiento = camForward * moviAvance + camRight * moviLateral;
        desplazamiento.Normalize(); // Asegurarse de que la magnitud sea 1 para mantener la velocidad constante.

        // Mover al jugador usando el componente Rigidbody en lugar de transform.Translate.
        rbJugador.MovePosition(rbJugador.position + desplazamiento * velocidad * Time.deltaTime);
    }

    void mirar()
    {
        // Capturar la entrada del ratón para rotar la cámara y el jugador.
        float xR = Input.GetAxis("Mouse X") * sensibilidadRaton * Time.deltaTime;
        float yR = Input.GetAxis("Mouse Y") * sensibilidadRaton * Time.deltaTime;

        // Actualizar la rotación vertical (cabeceo) y limitarla entre -90 y 90 grados.
        rotacionCabeceo -= yR;
        rotacionCabeceo = Mathf.Clamp(rotacionCabeceo, -90, 90);

        // Aplicar rotación a la cámara y el jugador.
        transform.Rotate(0, xR, 0);
        camara.transform.localRotation = Quaternion.Euler(rotacionCabeceo, 0, 0);
    }

    void disparar()
    {
        // Disparar un rayo desde la posición de la cámara en la dirección hacia adelante.
        Ray rayo = new Ray(camara.transform.position, camara.transform.forward);

        // Realizar una detección de colisión con objetos en el camino del rayo.
        RaycastHit disparo;

        if (Physics.Raycast(rayo, out disparo, distanciaDisparo) && disparo.rigidbody != null)
        {
            // Calcular una fuerza en dirección opuesta al normal de la superficie impactada y aplicarla al objeto.
            Vector3 vectorFuerza = -disparo.normal * fuerzaDisparo;
            disparo.rigidbody.AddForceAtPosition(vectorFuerza, disparo.point, ForceMode.Impulse);
        }
    }
}