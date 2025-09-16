using UnityEngine;

public class RagdollInputController : MonoBehaviour
{
    public RagdollWalker walker;
    public float baseWalkSpeed = 2f;

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");   // W/S

        if (Mathf.Abs(vertical) > 0.1f)
        {
            walker.walkSpeed = baseWalkSpeed;
        }
        else
        {
            walker.walkSpeed = 0f;
        }
    }
}
