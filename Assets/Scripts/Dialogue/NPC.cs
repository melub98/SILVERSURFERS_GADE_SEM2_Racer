using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public ActualDialogue dialogue;

    public void DialogueTrigger()//used to trigger the start of dialogue
    {
        FindObjectOfType<DialogueManager>().BeginDialogue(dialogue);
    }
}
