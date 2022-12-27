using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Template[] templateDialogue;
    public Animator animator;
    private Queue<string> sentences;
    bool isNull = false;
    public int index;
    public GameObject doneButton;
  

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        

        //propstemplates = FindObjectOfType<PropsTemplates>().id;
       // id = FindObjectOfType<PropsTemplates>().id;
    }

    public void StartDialogue(Template dialogue)
    {
      
           // TheEventManager.currentTemplate = template[id];
            animator.SetBool("IsOpen", true);
        // nameText.text = dialogue.name;
        //  nameText.text = template[ConversationTrigger.peopleId].name;
            nameText.text = templateDialogue[ConversationTrigger.instance.index].personName;
            
           descriptionText.text = templateDialogue[ConversationTrigger.instance.index].personDescription[index];
        sentences.Clear();

            foreach (string sentence in dialogue.personDescription)
            {
                sentences.Enqueue(sentence);
            }
        // DisplayNextSentence();

       // index = 0;

    }
    private void Update()
    {
            
        
    }
    public void DisplayNextSentence()
    {

        index++;
        if (sentences.Count ==0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        descriptionText.text = sentence;
       
        if (index >= templateDialogue[ConversationTrigger.instance.index].personDescription.Count-1)
        {
            doneButton.SetActive(true);
            return;

        }
      
       


        StartCoroutine(TypeSentence(sentence));

       

    }
    IEnumerator TypeSentence(string sentence)
    {
        descriptionText.text = "";
        
        foreach(char letter in templateDialogue[ConversationTrigger.instance.index].personDescription[index])
        {
       //  if(letter==null)
         //   {
          //      isNull = true;
         //   }
            descriptionText.text += letter;
            yield return null;
        }
    }
    public void DialgoueCompleted()
    {
        index = 0;
        descriptionText.text = "Press K to Message";
    }

   
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
   
}
