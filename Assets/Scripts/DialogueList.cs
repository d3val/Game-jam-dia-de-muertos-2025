using System.Collections.Generic;
using UnityEngine;

public class DialogueList : MonoBehaviour
{
    [SerializeField] private List<Dialogue> dialogues;
    private int currentDialogue = 0;

    private void Start()
    {
        Debug.Log("Total de dialogos: " + dialogues.Count);
    }

    public void NextDialogue()
    {
        if (currentDialogue >= dialogues.Count)
        {
            EndConversation();
            return;
        }

        DialogueUI.Instance.SetDialogue(dialogues[currentDialogue].speakerName, dialogues[currentDialogue].dialogueContent);
        currentDialogue++;
    }

    public void EndConversation()
    {
        DialogueUI.Instance.HideDialogueBox();
        currentDialogue = 0;
    }
}