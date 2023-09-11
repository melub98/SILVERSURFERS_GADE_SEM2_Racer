using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //variables for the in game dialogue
    public TextMeshProUGUI npcNameText;
    public TextMeshProUGUI dialogueText;
    public GameObject nextButton;
    

    //public Animator nxtAnimator;//animator for next button
    public Animator dBoxAnimator;//animator for the dialogue popping  up

    private Queue<string> dlogueSentnces;// queue strings for the sentences in dialogue
    
    void Start () {
        dlogueSentnces = new Queue<string>();//initialization of queue
        nextButton.SetActive(false);
    }

    public void BeginDialogue (ActualDialogue dialogue)//method for starting the game dialogue
    {
        nextButton.SetActive(false);
        dBoxAnimator.SetBool("DBoxIsOpen", true);//boolean to ensure dialogue box isnt always available
       // nxtAnimator.SetBool("NextIsVisible", false);

        npcNameText.text = dialogue.npcName; //assigning the speakers name
        
        dlogueSentnces.Clear();//used to clear the sentences from the dialogue

        foreach (string sentence in dialogue.actualSentences )//loop for looping through dialogue using the ADT queue
        {
            dlogueSentnces.Enqueue(sentence);
            
        }
        

        ShowNextSentence(); // calling method to display next sentence
    }

    public void ShowNextSentence ()//method for displaying the next sentence in queue
    {
        if (dlogueSentnces.Count == 0)
        {
            EndDialogue();//method call to stop dialogue so that the next sentence can be shown
            return;
        }

        string sentence = dlogueSentnces.Dequeue();//used to call next sentence in dialogue
        StopAllCoroutines();
        StartCoroutine(TypeDialogue(sentence));
    }

    IEnumerator TypeDialogue (string sentence)// coroutine for the dialogue to have a type effect
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    
    

    void EndDialogue()//method for stopping the dialogue
    {
        dBoxAnimator.SetBool("DBoxIsOpen", false);
        
    }

    

}
    

