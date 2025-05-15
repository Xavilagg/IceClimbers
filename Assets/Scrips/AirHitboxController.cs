using UnityEngine;

public class AirHitboxController : MonoBehaviour
{
    [SerializeField] Movement movementController;
    private void FixedUpdate()
    {
        if(movementController.grounded) gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
