using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoadFromFile : MonoBehaviour
{
    private string[] _fullReadFille;
    public string[,] QuestionsArray { get; private set; }
    public int CountQuestions { get; private set; }

    void Start()
    {
        _fullReadFille = Resources.Load<TextAsset>("InputData").text.Split(new char[] { ',', '\n'});
        CountQuestions = _fullReadFille.Length / 5;
        QuestionsArray = new string[CountQuestions, 5];

        int counter = 0;
        for (int i = 0; i < CountQuestions; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                QuestionsArray[i, j] = _fullReadFille[counter];
                counter++;
            }
        }
    }
}
