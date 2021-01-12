using System;
using UnityEngine;
using UnityEngine.UI;

public class MainGameMenager : MonoBehaviour
{
    public static MainGameMenager GameMenager { get; private set; }
    public int CountQuest { get; set; }
    public int CorrectAnswer { get; set; }
    public Text[] QuestAndAnswer;
    public string[,] dataQestAndAnswer;
    public GameObject[] Buttons;
    public LoadFromFile dataFromFile;

    private void Awake()
    {
        GameMenager = this;

        dataFromFile = new LoadFromFile();
        dataQestAndAnswer = dataFromFile.QuestionsArray;

        CountQuest = 5;
    }

    public void LoadQuest(int questNumber)
    {
        for (int i = 0; i < CountQuest; i++)
        {
            QuestAndAnswer[i].text = dataQestAndAnswer[questNumber, i];
        }
    }

    public bool CheckingAnswer(int questNumber, int selectAnswer)
    {
        CorrectAnswer = Convert.ToInt32(dataQestAndAnswer[questNumber, 5]);

        if (selectAnswer == CorrectAnswer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #region StandyMode
    public void StandyMode(bool isActive, Color colorSelectButton, int numberSelectButton)
    {
        if (isActive)
        {
            foreach (var button in Buttons)
            { 
                button.GetComponent<Button>().interactable = false;
                button.GetComponent<SelectAnswerEvent>().enabled = false;
            }
        }
        else
        {
            foreach (var button in Buttons)
            {
                button.GetComponent<Button>().interactable = true;
                button.GetComponent<SelectAnswerEvent>().enabled = true;
            }
        }

        Buttons[numberSelectButton - 1].GetComponent<Image>().color = colorSelectButton;
        Buttons[numberSelectButton - 1].GetComponent<Button>().interactable = true;
    }

    public void StandyMode(bool isActive)
    {
        if (isActive)
        {
            foreach (var button in Buttons)
            {
                button.GetComponent<Button>().interactable = false;
                button.GetComponent<SelectAnswerEvent>().enabled = false;
                button.GetComponent<Image>().color = Color.white;
            }

        }
        else
        {
            foreach (var button in Buttons)
            {
                button.GetComponent<Button>().interactable = true;
                button.GetComponent<SelectAnswerEvent>().enabled = true;
                button.GetComponent<Image>().color = Color.white;
            }
        }
    }
    #endregion
}