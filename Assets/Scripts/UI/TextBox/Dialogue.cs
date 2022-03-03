using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObject/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [System.Serializable]
    public struct DialogueStruct
    {
        public string name;
        [TextAreaAttribute(3, 10)]
        public string[] texts;
        
        public string GetName { get; }
        public string[] GetTexts { get; }
    }

    [SerializeField] public DialogueStruct[] dialogueStruct;
}
