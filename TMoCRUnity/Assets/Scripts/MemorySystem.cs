using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemorySystem : MonoBehaviour
{
    [SerializeField] private TMP_Text choiceA;
    [SerializeField] private TMP_Text choiceB;
    private int choiceCounter = 0;
    private Choice[] choices;
    private bool choiceC = false;
    private string choiceCText;
    void Start()
    {
        MemorySystemTriggerTest.OnTriggerEnter += OnChoiceMade;
        choices = ReadJson.JsonChoices.choices;
        choiceCText = "Go back with Michael and Jane to their house and take Melissa with you";
        WriteChoice();
    }

    private void OnChoiceMade(int choice)
    {
        if (choice == 0)
        {
            choiceCounter = choices[choiceCounter].resultA;
        }
        else if (choice == 1)
        {
            choiceCounter = choices[choiceCounter].resultB;
        }
        else
        {
            Debug.Log("Limit Error");
        }
        WriteChoice();
    }
    private void WriteChoice()
    {
        if (choiceCounter == 47) return;
        choiceA.text = choices[choiceCounter].choiceA;
        choiceB.text = choices[choiceCounter].choiceB;
        if (choiceCounter == 44)
        {
            choiceC = true;
        }
    }
}
