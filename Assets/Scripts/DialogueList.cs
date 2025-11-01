using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueList : MonoBehaviour
{
    [SerializeField] private List<Dialogue> dialogues;
    [SerializeField] private UnityEvent OnDialoguesEnd;
    private int currentDialogue = 0;

    public void NextDialogue()
    {
        if (currentDialogue >= dialogues.Count)
        {
            OnDialoguesEnd?.Invoke();
            EndConversation();
            return;
        }

        DialogueUI.Instance.SetDialogue(dialogues[currentDialogue].speakerName, dialogues[currentDialogue].dialogueContent);
        dialogues[currentDialogue].OnDialogueStart?.Invoke();
        currentDialogue++;
    }

    public void EndConversation()
    {
        DialogueUI.Instance.HideDialogueBox();
        currentDialogue = 0;
    }
}