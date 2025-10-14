using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] UnityEvent triggerInteraction;
    public void Interact()
    {
        triggerInteraction?.Invoke();
    }
}
