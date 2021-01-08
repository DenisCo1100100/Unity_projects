using System;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsMenager
{
    public string[] QestAndAnswer;
    private LoadFromFile dataFromFile;

    public int CountQuest { get; set; }
    public int CorrectAnswer { get; set; }

    public QuestionsMenager()
    {
        CountQuest = 5;
    }

    public void LoadQuest(Text[] questAndAnswer, int questNumber)
    {
        dataFromFile = new LoadFromFile();

        for (int i = 0; i < CountQuest; i++)
        {
            questAndAnswer[i].text = dataFromFile.QuestionsArray[questNumber, i];
        }
    }

    public bool CheckingAnswer(int questNumber, int selectAnswer)
    {
        CorrectAnswer = Convert.ToInt32(dataFromFile.QuestionsArray[questNumber, 5]);

        if (selectAnswer == CorrectAnswer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}