using UnityEngine;

public class AirHitboxController : MonoBehaviour
{
    [SerializeField] Movement movementController;
    Rigidbody2D rb;
    bool hasBroken = false;

    private void OnEnable()
    {
        hasBroken = false;
        if(rb == null) rb = GetComponentInParent <Rigidbody2D> ();
    }
    private void FixedUpdate()
    {
        if (movementController.grounded) gameObject.SetActive(false);
        if (rb.linearVelocityY < 0) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable") && !hasBroken)
        {
            hasBroken = true;
            collision.gameObject.SetActive(false);
            rb.linearVelocityY = 0;
        }
    }
}
