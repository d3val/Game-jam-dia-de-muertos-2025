using UnityEngine;

public class Collectable : Interactable
{
    public override void Interact()
    {
        Destroy(gameObject);
    }
}
