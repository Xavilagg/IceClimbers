using UnityEngine;
using static UnityEngine.InputSystem.InputAction;



public class AttackController : MonoBehaviour
{
    Movement movementController;
    [SerializeField] GameObject jumpAttackBox;
    [SerializeField] GameObject groundedAttackBox;
    [SerializeField] Transform attackBoxesParent;
    public bool isAttacking;

    void Awake()
    {
        movementController = GetComponent<Movement>();

    }

    void Start()
    {
        jumpAttackBox.SetActive(false);
        groundedAttackBox.SetActive(false);
    }
public void Attack_Event (CallbackContext context)
    {
        if(context.performed)
        {
            if (movementController.grounded)
            {
                groundedAttackBox.SetActive(true);
            }
            else
            {
                jumpAttackBox.SetActive(true);
            }
        }
    }
    private void FixedUpdate()
    {
        //attackBoxesParent.localScale = movementController.direction.x > 0 ? Vector3.one : new Vector3(-1, 1, 1);
        if (isAttacking) return;
        if (movementController.direction.x > 0) attackBoxesParent.localScale = Vector3.one;
        else if (movementController.direction.x < 0) attackBoxesParent.localScale = new Vector3(-1, 1, 1);
    }
}
