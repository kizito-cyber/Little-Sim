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
    public bool isShopKeeper = false;
    public GameObject shopPanel;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        

    }

    public void StartDialogue(Template dialogue)
    {

        if (templateDialogue[ConversationTrigger.instance.index].isShopManager)
        {

          isShopKeeper= true;
            animator.SetBool("IsOpen", true);
          
            nameText.text = templateDialogue[ConversationTrigger.instance.index].shopManagerName;

            descriptionText.text = templateDialogue[ConversationTrigger.instance.index].ShopManagerDescription;
            sentences.Clear();

            foreach (string sentence in dialogue.personDescription)
            {
                sentences.Enqueue(sentence);
            }
           

            doneButton.SetActive(true);
        }
        else
        {
            animator.SetBool("IsOpen", true);

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



    }
    private void Update()
    {
        if(isShopKeeper)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                shopPanel.SetActive(true);
            }
        }
      
    }
    public void DisplayNextSentence()
    {
        if(DialogueTrigger.dialogueStarted)

        {
            index++;
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            descriptionText.text = sentence;
            if (index > templateDialogue[ConversationTrigger.instance.index].personDescription.Count - 1)
            {
                doneButton.SetActive(true);
                return;
            }
            StartCoroutine(TypeSentence(sentence));

        }

    }
    IEnumerator TypeSentence(string sentence)
    {
        descriptionText.text = "";
        
        foreach(char letter in templateDialogue[ConversationTrigger.instance.index].personDescription[index])
        {
      
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
