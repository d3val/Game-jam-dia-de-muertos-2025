using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent triggerInteraction;
    [SerializeField] UnityEvent onInterruptInteraction;
    [SerializeField] GameObject uiIndicator;
    public void Interact()
    {
        EnableUIIndicator(false);
        triggerInteraction?.Invoke();
    }

    public void Interrupt()
    {
        onInterruptInteraction?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) EnableUIIndicator(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) EnableUIIndicator(false);
    }

    public void EnableUIIndicator(bool state) => uiIndicator.SetActive(state);

}