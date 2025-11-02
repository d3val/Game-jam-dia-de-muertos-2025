using UnityEngine;

public class BreadBox : MonoBehaviour
{
    [SerializeField] DialogueList dialogueList;
    [SerializeField] Sprite openSprite;
    private bool isOpen = false;

    public void OpenBox()
    {
        if (isOpen) return;

        if (ItemsManager.Instance.holdingKey)
        {
            ItemsManager.Instance.AddBread();
            GetComponent<Collider>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = openSprite;
            isOpen = true;
            return;
        }

        dialogueList.NextDialogue();
    }
}