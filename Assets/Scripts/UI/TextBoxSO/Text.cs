using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextBox", menuName = "ScriptableObjects/CreateTextBox", order = 1)]
public class Text : ScriptableObject
{
    public string character;
    public string text;
}
