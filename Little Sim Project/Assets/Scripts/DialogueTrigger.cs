using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Template[] dialogue;
    public static bool dialogueStarted = false;


    private void Update()
    {
        TriggerDialogue();
    }
    public void TriggerDialogue()
    {
       // Vector2.Distance(player.transform.position, astronaut.transform.position) < 3
        if (ConversationTrigger.inRange && Input.GetKeyDown(KeyCode.K))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue[ConversationTrigger.instance.index]);
           dialogueStarted= true;
        }
      
        
    }

}
