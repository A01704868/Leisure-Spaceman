using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // variables del target que va a rotar y a que velocidad
    [SerializeField] private Transform target;
    [SerializeField] private int speed;

    // Update is called once per frame
    void Update()
    {
        // agregar el efecto de rotacion sobre su eje para el planeta tierra
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }
}
