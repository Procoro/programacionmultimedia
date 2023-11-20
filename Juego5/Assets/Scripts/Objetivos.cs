using UnityEngine;

public class Objetivos : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rbObjetivo;

    private float rangoX = 4.0F;
    private float posY = -1.0f;
    private float minVelocidad = 12.0F;
    private float maxVelocidad = 16.0f;
    private float fuerzaTorsion = 10.0f;
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        rbObjetivo = GetComponent<Rigidbody>();
        transform.position = posGeneracion();


        rbObjetivo.AddForce(FuerzaImpulso(), ForceMode.Impulse);
        //añadimos fuerza de giro
        rbObjetivo.AddTorque(ValorTorsion(), ValorTorsion(),
           ValorTorsion(), ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 posGeneracion()
    {
        return new Vector3(Random.Range(-rangoX, rangoX), posY);
    }


    Vector3 FuerzaImpulso()
    {
        return Vector3.up * Random.Range(minVelocidad, maxVelocidad);
    }
    float ValorTorsion()
    {
        return Random.Range(-fuerzaTorsion, fuerzaTorsion);


    }

}
