using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent triggerInteraction;
    [SerializeField] UnityEvent onInterruptInteraction;
    public void Interact()
    {
        triggerInteraction?.Invoke();
    }

    public void Interrupt()
    {
        onInterruptInteraction?.Invoke();
    }

}
