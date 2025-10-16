using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Dialogue
{
    [TextArea] public string dialogueContent;
    public UnityEvent OnDialogueStart;
}