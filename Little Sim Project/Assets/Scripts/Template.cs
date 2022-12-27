using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
[CreateAssetMenu(fileName ="New Dialogue",menuName ="Dialogue")]
public class Template : ScriptableObject
{

    public string personName;
    [TextArea(5, 5)]
    public List<string> personDescription = new List<string>();
   
    [Space]
    public bool NotNPC;
    [ShowIf("NotNPC")]
    public List<string> dialogueName = new List<string>();
    [ShowIf("NotNPC")]
    public List<string> dialogueDescription = new List<string>();
    [Space]
    public bool isShopManager;
    [ShowIf("isShopManager")]
    public string shopManagerName;
    [ShowIf("isShopManager")]
    [TextArea(5, 5)]
    public string ShopManagerDescription;

}
