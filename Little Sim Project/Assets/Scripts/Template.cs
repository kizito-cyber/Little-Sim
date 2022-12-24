using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="New Template",menuName ="Template")]
public class Template : ScriptableObject
{
    public string name;
    public string story;
    public string[] description;
    public int propId;
    public int numberOfPresses;
    public int pressCounter;
    public int lastUnlockedStory;

}
