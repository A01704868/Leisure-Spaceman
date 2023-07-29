using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    // El constante de gravedad G
    readonly float G = 40f;

    // Para guardar a todos los objetos con el tag de "celestial"
    GameObject[] celestials;

    // Start is called before the first frame update
    void Start()
    {
        // llenar variable con todos los celestials
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        // iniciar velocidad de cada objeto
        InitialVelocity();
    }
    // calcular la fuerza de gravedad cada intervalo fijo de fps
    private void FixedUpdate()
    {
        // llamar funcion que calcula la fuerza de gravedad
        Gravity();
    }
    // agregar la fuerza de gravedad a cada uno de los cuerpos celestiales
    void Gravity()
    {
        foreach(GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                   // calcular los constantes para la formula
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    // ahora si calcular la fuerza que ejerce cada cuerpo sobre la gravedad del cuerpo correspondiente y agregar esa fuerza a su rigidbody para que se mueva
                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2)/(r * r)));
                }
            }
        }
    }
    // Una funcion que calcula la velocidad inicial de cada celestial relativo a su cuerpo celestial mas cercano basado en la ley de newton
    void InitialVelocity()
    {
        // por cada uno de los celestiales
        foreach (GameObject a in celestials)
        {
            // por cada uno de los celestiales restantes
            foreach (GameObject b in celestials)
            {
                // si a y b no son el mismo cuerpo celestial
                if (!a.Equals(b))
                {
                    // obtener la massa y el radio de b
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);
                    // m1 se cancela
                    // queda g * m2 dividido por r
                    // agregar a la transformacion a la derecha para empezar con la rotacion
                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2)/ r);
                }
            }
        }
    }
}
