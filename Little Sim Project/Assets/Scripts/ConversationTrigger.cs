using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public static bool enterRange = false;
    public static int peopleId;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D col in hitColliders)
        {
            if(col.CompareTag("Person"))
            {
                Debug.Log(col.name);
            }
          
            
        }
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Person"))
        {
            enterRange = true;
           peopleId= collision.GetComponent<PropsTemplates>().id;

            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Person"))
        {
            enterRange = false;
        }
    }*/
}
