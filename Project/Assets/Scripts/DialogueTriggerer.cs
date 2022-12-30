using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerer : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    public Dialogue Dialogue => dialogue;

    public void TriggerDialogue() => DialogueManager.I.StartDialogue(dialogue);
}
