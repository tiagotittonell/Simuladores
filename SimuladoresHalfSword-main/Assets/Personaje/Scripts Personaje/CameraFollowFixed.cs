using UnityEngine;

public class CameraFollowFixed : MonoBehaviour
{
    public Transform target;      // PlayerRoot
    public Vector3 offset;        // se calcula según donde pongas la cámara en la escena
    public float followSpeed = 5f;

    void Start()
    {
        if (target != null)
        {
            // Guardamos la diferencia inicial entre la cámara y el personaje
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        if (!target) return;

        // La cámara sigue la posición del personaje manteniendo siempre el offset inicial
        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);

        // Cámara mira siempre al personaje
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
