using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;
    public GameObject astronaut;
    public int id;
    public void TriggerDialogue()
    {
       // Vector2.Distance(player.transform.position, astronaut.transform.position) < 3
        if (ConversationTrigger.enterRange)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        
    }

}
