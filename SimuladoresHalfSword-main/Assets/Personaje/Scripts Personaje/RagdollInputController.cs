using UnityEngine;

public class RagdollInputController : MonoBehaviour
{
    public RagdollWalker walker;
    public float baseWalkSpeed = 2f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        // Pasar input al walker
        walker.SetInput(h, v);

        // Controla solo la velocidad de las piernas
        walker.walkSpeed = (Mathf.Abs(v) > 0.1f) ? baseWalkSpeed : 0f;
    }
}
