using UnityEngine;
using UnityEngine.InputSystem;

public class FireActionManager : MonoBehaviour
{
    public InputActionAsset inputActions;
    public RobotHeadController robotHeadController;

    private InputAction triggerFire;

    private void Awake()
    {
        triggerFire = inputActions.FindActionMap("DebugActions").FindAction("TriggerFire");
    }

    private void OnEnable()
    {
        triggerFire.Enable();
        triggerFire.performed += OnFireTriggered;
    }

    private void OnDisable()
    {
        triggerFire.performed -= OnFireTriggered;
        triggerFire.Disable();
    }

    private void OnFireTriggered(InputAction.CallbackContext context)
    {
        robotHeadController.StartFire();
    }
}
