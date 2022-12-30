using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]

public class Dialogue
{
    [SerializeField] string name;
    [TextArea(1, 7)]
    [SerializeField] string[] sentences;

    public string Name => name;
    public string[] Sentences => sentences;
}
