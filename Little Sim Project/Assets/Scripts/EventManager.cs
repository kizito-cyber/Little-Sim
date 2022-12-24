using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action<int> IncreaseStory;
    public static Character currentCharacter;

    public static void Pressed(int id)
    {
        IncreaseStory?.Invoke(id);
    }
}
