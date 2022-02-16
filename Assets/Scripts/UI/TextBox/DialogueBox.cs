using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    
    public void ShowBoxWithText(Queue<string> Queue)
    {
        nameText.SetText(Queue.Dequeue());
        dialogueText.SetText(Queue.Dequeue());
    }
}
