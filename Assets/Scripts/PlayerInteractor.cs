using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actionAsset;
    private InputAction _interactAction;
    private Interactable _currentInteractable;

    private void Awake()
    {
        _interactAction = _actionAsset.FindActionMap("Player").FindAction("Interact");
    }

    private void OnEnable()
    {
        _interactAction.performed += TriggerInteraction;
    }

    private void OnDisable()
    {
        _interactAction.performed -= TriggerInteraction;
    }

    private void TriggerInteraction(InputAction.CallbackContext ctx)
    {
        if (_currentInteractable == null) return;

        Debug.Log("Accion");
        _currentInteractable.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            _currentInteractable = other.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Interactable")) return;

        if (other.GetComponent<Interactable>() != _currentInteractable)
        {
            return;
        }
        else
        {
            _currentInteractable.Interrupt();
            _currentInteractable = null;
        }
    }
}