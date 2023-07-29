using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    // variables para guardar los cambios del mouse
    float rotationX = 0f;
    float rotationY = 0f;
    // que tan elastico es el cambio de rotacion en relacion al movimiento del mouse
    [SerializeField] private float sensitivity = 3f;

    // Update is called once per frame
    void Update()
    {
        // hacer que la rotacion sea igual a las coordenadas del mouse multiplicadas por la sensitividad
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        // hacer la transformacion del angulo tomando encuenta las nuevas rotaciones
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
