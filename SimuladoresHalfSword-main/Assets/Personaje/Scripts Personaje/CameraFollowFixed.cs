using UnityEngine;

public class CameraFollowFixed : MonoBehaviour
{
    public Transform target;      // PlayerRoot
    public Vector3 offset;        // se calcula seg�n donde pongas la c�mara en la escena
    public float followSpeed = 5f;

    void Start()
    {
        if (target != null)
        {
            // Guardamos la diferencia inicial entre la c�mara y el personaje
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        if (!target) return;

        // La c�mara sigue la posici�n del personaje manteniendo siempre el offset inicial
        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);

        // C�mara mira siempre al personaje
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
