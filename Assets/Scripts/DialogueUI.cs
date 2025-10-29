using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }
    [SerializeField] private GameObject dialogueBox;
    [SerializeField]private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerNameText;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);

        Instance = this;
    }

    public void SetDialogue(string speakerName, string dialogueContent)
    {
        dialogueBox.SetActive(true);
        dialogueText.SetText(dialogueContent);
        speakerNameText.SetText(speakerName);
    }

    public void HideDialogueBox()
    {
        dialogueText.SetText(string.Empty);
        dialogueBox.SetActive(false);
    }
}