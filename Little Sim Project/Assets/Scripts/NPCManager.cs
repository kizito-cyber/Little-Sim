using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject NPCsPrefab;
    public int index;
    public static NPCManager instance;
    public List<GameObject> NPCList = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
       
    }

    private void Start()
    {
        index = NPCList.Count;

       
        for (int i = 0; i < 2; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-11, 15), Random.Range(-11, 12), transform.position.z);
            GameObject clone = Instantiate(NPCsPrefab, randomPos, Quaternion.identity);

            NPCList.Add(clone);
            index = NPCList.Count;
        }


    }
    // Update is called once per frame
    void Update()
    {
      
       
    }





   
}
