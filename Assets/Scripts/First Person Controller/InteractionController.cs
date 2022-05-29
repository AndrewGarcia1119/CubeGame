using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField]
    float interactDistance = 2f;

    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        enabled = false;
    }

    private void OnEnable()
    {
        playerInput.Player.Enable();
        playerInput.Player.Interact.performed += TryInteraction;
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    private Ray GetScreenCenterRay()
    {
        return Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void TryInteraction(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (Physics.Raycast(GetScreenCenterRay(), out RaycastHit hit, interactDistance))
        {
            Item item = hit.transform.GetComponentInParent<Item>();
            if (item == null) return;
            item.Take();
        }
    }

}
