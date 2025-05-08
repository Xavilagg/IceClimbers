using UnityEngine;
using static UnityEngine.InputSystem.InputAction;



public class AttackController : MonoBehaviour
{
    Movement movementController;
    [SerializeField] GameObject jumpAttackBox;
    [SerializeField] GameObject groundedAttackBox;
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
    void Update()
    {
        
    }
}
