using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Character[] Heroes;
    public Character[] Villans;
    public Button[] Buttons;
    private bool initializeHeroes = false;
    private bool initializeVillans = false;

    private void Start()
    {
        for (int i = 0; i < Heroes.Length; i++)
        {
            //Heroes[i].IsAllUnlocked = false;
            Heroes[i].pressCounter = 0;
            Heroes[i].lastUnlockedStory = 0;
            Heroes[i].currentStory = Heroes[i].story[0];
            Heroes[i].characterId = i;
        }

        for (int i = 0; i < Heroes.Length; i++)
        {
            //Villans[i].IsAllUnlocked = false;
            Villans[i].pressCounter = 0;
            Villans[i].lastUnlockedStory = 0;
            Villans[i].currentStory = Villans[i].story[0];
            Villans[i].characterId = i;
        }
    }

    public void HeroesSelect()
    {
        for (int i = 0; i < Heroes.Length; i++)
        {
            Buttons[i].gameObject.SetActive(true);
            Buttons[i].GetComponent<ShowCharacter>().character = Heroes[i];
            Buttons[i].GetComponent<ShowCharacter>().Display();
            Buttons[i].GetComponent<ShowCharacter>().characterStory.text = "";
        }
        for (int i = Heroes.Length; i < Buttons.Length; i++)
            Buttons[i].gameObject.SetActive(false);
    }

    public void VillansSelect()
    {
        for (int i = 0; i < Villans.Length; i++)
        {
            Buttons[i].GetComponent<ShowCharacter>().character = Villans[i];
            Buttons[i].GetComponent<ShowCharacter>().Display();
            Buttons[i].GetComponent<ShowCharacter>().characterStory.text ="";
        }
        for (int i = Villans.Length; i < Buttons.Length; i++)
            Buttons[i].gameObject.SetActive(false);
    }
}
