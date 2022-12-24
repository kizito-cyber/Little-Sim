using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    public Template[] template;
    bool isNull = false;
    //PropsTemplates propstemplates;
    public int index = -1;
    

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        //propstemplates = FindObjectOfType<PropsTemplates>().id;
       // id = FindObjectOfType<PropsTemplates>().id;
    }

    public void StartDialogue(Dialogue dialogue)
    {
      
           // TheEventManager.currentTemplate = template[id];
            animator.SetBool("IsOpen", true);
            // nameText.text = dialogue.name;
            nameText.text = template[ConversationTrigger.peopleId].name;
            sentences.Clear();

            foreach (string sentence in dialogue.templates)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();

        

    }
    private void Update()
    {
       
            
        
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count ==0)
        {
            EndDialogue();
            return;
        }
        if(isNull)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        index++;
        StartCoroutine(TypeSentence(sentence));
        if(index>=2)
        {
            index = -1;
        }
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        
        foreach(char letter in template[ConversationTrigger.peopleId].description[index])
        {
          if(letter==null)
            {
                isNull = true;
            }
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
   
}
