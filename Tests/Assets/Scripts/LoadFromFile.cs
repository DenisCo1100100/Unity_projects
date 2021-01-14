using System;
using System.IO;
using UnityEngine;

public class LoadFromFile
{
    public string ThemeText { get; private set; }
    public string[,] QuestionsArray { get; private set; }
    public int CountQuestions { get; private set; }

    private string[] _fullReadFille;
    
    public LoadFromFile()
    {
        _fullReadFille = Resources.Load<TextAsset>("Unity development").text.Split(new char[] { ';', '\n'});
        CountQuestions = Convert.ToInt32(_fullReadFille[_fullReadFille.Length - 1]);
        FormattingFilleData();
    }

    private void FormattingFilleData()
    {
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

    public void FormattingFilleData(string path)
    {
        ThemeText = path.Split(new char[] { '\\', '.', '/'})[path.Split(new char[] { '\\', '.', '/' }).Length -2];

        using (StreamReader sr = new StreamReader(path))
        {
            _fullReadFille = sr.ReadToEnd().Split(new char[] { ';', '\n' });
        }

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