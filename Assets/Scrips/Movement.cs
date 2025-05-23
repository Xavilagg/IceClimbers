using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    AttackController attackController;
    [SerializeField] float jumpForce;
    public bool grounded;

    [SerializeField] LayerMask groundedRCLayerMask;
    public float movespeed = 0;
    public Vector3 direction = Vector3.zero;
    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        attackController = GetComponent<AttackController>();
    }
    void FixedUpdate()
    {
        
        //Origen, direccion, distancia,collision filter 
        grounded = (Physics2D.Raycast(transform.position, Vector2.down, 1.05f, groundedRCLayerMask));
        if (attackController. isAttacking)
        {
            rb.linearVelocityX = 0;
            return;
        }
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

    public void Jump_Event (CallbackContext context)
    {
        if(context.performed)
        {
            if (grounded && !attackController.isAttacking) rb.linearVelocityY = jumpForce;
        }
    }
}
