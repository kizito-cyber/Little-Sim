using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int NPCIndex;
    public static NPC Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance= this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
