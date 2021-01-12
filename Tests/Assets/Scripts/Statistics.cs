using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    #region inspector
    [SerializeField] private Slider _progresBar;
    [SerializeField] private Text _progresText;
    [SerializeField] private Text _comments;
    #endregion

    public static Statistics Stats { get; set; }
    public int CountQuest { get; set; }
    public int CountCorectAnswer { get; set; }

    private void Awake()
    {
        Stats = this;
    }

    public void PrintStatistics()
    {
        CountQuest = MainGameMenager.GameMenager.dataFromFile.CountQuestions;
        _progresBar.maxValue = CountQuest;
        _progresBar.value = CountCorectAnswer;
        _progresText.text = $"{CountCorectAnswer}/{_progresBar.maxValue} ({ColculatePercent()}%)";
        ResultComments();
    }

    private double ColculatePercent() 
    { 
        return CountCorectAnswer > 0 ? (CountCorectAnswer * 100) / CountQuest : 0;
    }

    private void ResultComments()
    {
        if(ColculatePercent() < 30)
        {
            _comments.text = "GOOD JOB!\nYour knowledge at the JUNIOR developer level";
        }
        else if(ColculatePercent() > 30 && ColculatePercent() < 70)
        {
            _comments.text = "GOOD JOB!\nYour knowledge at the MIDLE developer level";
        }
        else
        {
            _comments.text = "GOOD JOB!\nYour knowledge at the SENIOR developer level";
        }
    }

    public void ResetStat()
    {
        CountQuest = 0;
        CountCorectAnswer = 0;
    }
}
