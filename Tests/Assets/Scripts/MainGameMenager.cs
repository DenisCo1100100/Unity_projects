using System;
using UnityEngine;
using UnityEngine.UI;

public class MainGameMenager : MonoBehaviour
{
    #region Inspector
    public Text[] QuestAndAnswer;
    public GameObject[] Buttons;
    #endregion

    public static MainGameMenager GameMenager { get; private set; }
    public int CorrectAnswer { get; set; }
    public string[,] dataQestAndAnswer;
    public LoadFromFile dataFromFile;

    private void Awake()
    {
        GameMenager = this;

        dataFromFile = new LoadFromFile();
    }

    public void LoadQuest(int questNumber)
    {
        dataQestAndAnswer = dataFromFile.QuestionsArray;

        for (int i = 0; i < 5; i++)
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
        Buttons[CorrectAnswer - 1].GetComponent<Image>().color = Color.green;
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