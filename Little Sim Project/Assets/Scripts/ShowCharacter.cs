using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    public Character character;
    public Text characterName;
    public Text characterStory;
    //public int pressCounter;

    private void Start()
    {
        EventManager.IncreaseStory += AddStory;
    }

    public void Display()
    {
        characterName.text = character.name;
        //character.currentStory = character.story[0];
        //characterStory.text = character.story;
    }

    public void ShowStory(int id)
    {
        bool yes = (character.lastUnlockedStory + 1 == character.story.Length);
        if (id == character.characterId)
        {
            EventManager.currentCharacter = character;
            characterStory.text = character.currentStory + "\n\n" + ((!yes) ? $"<b>Unlock more information by clicking the " +
            $"button {character.numberOfPresses - character.pressCounter} times</b>" : "");
        }
    }

    public void Press()
    {
        bool yes = (EventManager.currentCharacter.lastUnlockedStory + 1 == EventManager.currentCharacter.story.Length);
        EventManager.currentCharacter.pressCounter += 1;
        characterStory.text = EventManager.currentCharacter.currentStory + "\n\n" + ((!yes) ? $"<b>Unlock more information by clicking the " +
            $"button {EventManager.currentCharacter.numberOfPresses - EventManager.currentCharacter.pressCounter} times</b>" : "");

        if (EventManager.currentCharacter.pressCounter == EventManager.currentCharacter.numberOfPresses)
        {
            EventManager.currentCharacter.pressCounter = 0;
            EventManager.Pressed(EventManager.currentCharacter.characterId);
            //EventManager.currentCharacter.IsAllUnlocked = EventManager.currentCharacter.lastUnlockedStory + 1 == EventManager.currentCharacter.story.Length - 1;
        }
    }

    public void AddStory(int id)
    {
        //Debug.Log(character.story.Length);
        bool yes = (EventManager.currentCharacter.lastUnlockedStory + 1 == EventManager.currentCharacter.story.Length - 1);
        id = EventManager.currentCharacter.characterId;
        if (id == character.characterId && character.lastUnlockedStory + 1 < character.story.Length)
        {
            character.currentStory += "\n" + character.story[character.lastUnlockedStory+1];
            characterStory.text = character.currentStory + "\n\n" + ((!yes) ? $"<b>Unlock more information by clicking the " +
            $"button {character.numberOfPresses - character.pressCounter} times</b>" : "");
            character.lastUnlockedStory += 1;
        }
    }
}
