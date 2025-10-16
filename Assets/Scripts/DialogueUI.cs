using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }
    [SerializeField] private GameObject dialogueBox;
    private TextMeshProUGUI dialogueText;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);

        Instance = this;
        dialogueText = dialogueBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetDialogue(string dialogueContent)
    {
        dialogueBox.SetActive(true);
        dialogueText.SetText(dialogueContent);
    }

    public void HideDialogueBox()
    {
        dialogueText.SetText(string.Empty);
        dialogueBox.SetActive(false);
    }
}