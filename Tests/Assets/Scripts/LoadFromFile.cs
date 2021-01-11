using System;
using UnityEngine;

public class LoadFromFile
{
    public const int countAnswer = 5;

    private string[] _fullReadFille;
    public string[,] QuestionsArray { get; private set; }
    public int CountQuestions { get; private set; }

    public LoadFromFile()
    {
        _fullReadFille = Resources.Load<TextAsset>("InputData").text.Split(new char[] { ',', '\n'});
        CountQuestions = Convert.ToInt32(_fullReadFille[_fullReadFille.Length - 1]);
        QuestionsArray = new string[CountQuestions, 6];

        int counter = 0;
        for (int i = 0; i < CountQuestions; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                QuestionsArray[i, j] = _fullReadFille[counter];
                counter++;
            }
        }
    }
}