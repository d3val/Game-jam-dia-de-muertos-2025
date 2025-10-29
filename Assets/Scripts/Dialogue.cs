using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Dialogue
{
    public string speakerName;
    [TextArea] public string dialogueContent;
    public UnityEvent OnDialogueStart;
}