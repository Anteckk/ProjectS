using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObject/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    public string name;
    public string[] text;
}
