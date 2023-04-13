using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticQuizScript : MonoBehaviour
{
    public Image animalImage;
    public Button generateButton;
    public Button[] optionButtons;
    public Text[] buttonTexts;
    public Sprite[] animals;
    public Text correctText, incorrectText;
    private int correct, incorrect;
    private string correctAnswer;

    private string[] animalNames = { "Lion", "Tiger", "Giraffe", "Elephant", "Zebra" };

    // Start is called before the first frame update
    void Start()
    {
        // At start, make all option buttons non-interactable
        foreach (Button button in optionButtons)
        {
            button.interactable = false;
        }

        // Add an onClick listener to the generate button
        generateButton.onClick.AddListener(GenerateQuestion);

        // Add onClick listeners to the option buttons
        foreach (Button button in optionButtons)
        {
            button.onClick.AddListener(delegate { CheckAnswer(button.GetComponentInChildren<Text>().text); });
        }
    }

    void GenerateQuestion()
    {
        string[] animalNamesCopy = new string[animalNames.Length];
        Array.Copy(animalNames, animalNamesCopy, animalNames.Length);
        List<string> animalNamesList = new List<string>(animalNamesCopy);

        // Choose a random animal name as the correct answer
        int rand = UnityEngine.Random.Range(0, animalNames.Length);
        correctAnswer = animalNames[rand];
        animalImage.sprite = animals[rand];

        int correctButtonIndex = UnityEngine.Random.Range(0, optionButtons.Length);
        buttonTexts[correctButtonIndex].text = correctAnswer;

        // Remove the correct answer from the animal names list
        animalNamesList.Remove(correctAnswer);

        for(int i=0; i<buttonTexts.Length; i++)
        {
            if (buttonTexts[i].text == "")
            {
                int randomIndex = UnityEngine.Random.Range(0, animalNamesList.Count);
                buttonTexts[i].text = animalNamesList[randomIndex];
                animalNamesList.RemoveAt(randomIndex);
            }
        }

        // Make all option buttons interactable
        foreach (Button button in optionButtons)
        {
            button.interactable = true;
        }

        // Make the generate button non-interactable
        generateButton.interactable = false;
    }

    public void CheckAnswer(string buttonText)
    {
        for(int i=0; i<buttonTexts.Length; i++)
        {
            buttonTexts[i].text = "";
        }
        if (buttonText == correctAnswer)
        {
            correct++;
            correctText.text = correct.ToString();
            Debug.Log("Correct!");
        }
        else
        {
            incorrect++;
            incorrectText.text = incorrect.ToString();
            Debug.Log("Incorrect!");
        }

        // Make all option buttons non-interactable
        foreach (Button button in optionButtons)
        {
            button.interactable = false;
        }

        // Make the generate button interactable
        generateButton.interactable = true;
    }

    public void ResetScore()
    {
        correct = 0;
        incorrect = 0;
        correctText.text = correct.ToString();
        incorrectText.text = incorrect.ToString();
    }
}
