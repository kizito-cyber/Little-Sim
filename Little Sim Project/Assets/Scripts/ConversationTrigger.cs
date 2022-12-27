using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConversationTrigger : MonoBehaviour
{
    
    public static int peopleId;
    public float radius;
    public static bool inRange = false;
    public int index;
    public static ConversationTrigger instance;
    public GameObject chatButton;
    public GameObject dialoguePanel;
    
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange==false)
        {
            chatButton.SetActive(false);
            dialoguePanel.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Person"))
        {
            inRange = true;
            index = collision.GetComponent<NPC>().NPCIndex;
            dialoguePanel.SetActive(true);
            chatButton.SetActive(true);
            chatButton.transform.position = new Vector2(collision.transform.position.x+.5f,collision.transform.position.y+ 1.3f);
         
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Person"))
        {
            inRange = false;
        }
    }
}
