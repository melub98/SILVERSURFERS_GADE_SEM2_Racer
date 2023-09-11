using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/Dialogue Path")]
public class ActualDialogue : ScriptableObject
{
   
    public string  npcName;//string to store the speaker name
    
    [TextArea(3, 10)]
    public string[] actualSentences;// string array to store the sentences in the dialogue
   
}
