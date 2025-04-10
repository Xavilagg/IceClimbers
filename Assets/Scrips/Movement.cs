using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float movespeed = 0;
    Vector3 direction = Vector3.zero;
    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.linearVelocityX = direction.x * movespeed;
    }
    public void Move_Event (CallbackContext context)
    {
        if(context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            direction.x = input.x;
            direction.z = input.y;
        }

        else
        {
            direction = Vector3.zero;
        }
    }
}
