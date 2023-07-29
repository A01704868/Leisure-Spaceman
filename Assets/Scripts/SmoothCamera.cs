using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    #region Variables
    // variables
    // para guardar la diferencia entre las posiciones de la camara y el target
    private Vector3 _offset;
    // target es el objeto que se va a seguir la camara
    [SerializeField] private Transform target;
    // constante de que tan cerca lo va a seguir
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    #endregion

    #region Unity callbacks

    // calcular el offset
    private void Awake() => _offset = transform.position - target.position;

    private void LateUpdate()
    {
        // hacer que la camara siga al objeto deseado, en este caso es diseñado para seguir la luna
        // hay la opcion de que sea "smoothed" pero el variable de smoothTime se mantiene en 0 para que lo siga al mismo paso siempre
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }

    #endregion
}