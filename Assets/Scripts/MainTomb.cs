using UnityEngine;

public class MainTomb : MonoBehaviour
{
    [SerializeField] private GameObject placedItems;
    [SerializeField] private Animator spiritAnimator, finalPanelAnimator;
    [SerializeField] private DialogueList defaultDialogues, finalDialogues;
    private bool finalEventInitiated;

    public void PlaceItems()
    {
        if (finalEventInitiated)
        {
            finalDialogues.NextDialogue();
            return;
        }
        if (!ItemsManager.Instance.CheckItems())
        {
            defaultDialogues.NextDialogue();
            return;
        }
        else
        {
            InitFinalEvent();
        }

    }

    private void InitFinalEvent()
    {
        finalEventInitiated = true;
        placedItems.SetActive(true);
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().DisableMove();
        GameObject.FindFirstObjectByType<GameManager>().StopTimer();
        finalDialogues.NextDialogue();
    }

    public void EndGame() => finalPanelAnimator.SetTrigger("EndGame");
}