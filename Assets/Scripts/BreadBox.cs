using UnityEngine;

public class BreadBox : MonoBehaviour
{
    [SerializeField] DialogueList dialogueList;
    [SerializeField] Sprite openSprite;

    public void OpenBox()
    {
        if (ItemsManager.Instance.holdingKey)
        {
            ItemsManager.Instance.AddBread();
            GetComponent<Collider>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = openSprite;
            return;
        }

        dialogueList.NextDialogue();
    }
}