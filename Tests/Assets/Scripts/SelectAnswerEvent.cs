using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectAnswerEvent : MonoBehaviour, IPointerClickHandler
{
    private int numberSelectButton;
    private GameObject selectButton;
    public static int _questNumber;

    private void Start()
    {
        _questNumber = 0;
        MainGameMenager.GameMenager.LoadQuest(_questNumber);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selectButton = eventData.pointerCurrentRaycast.gameObject;
        numberSelectButton = Convert.ToInt32(selectButton.tag);

        if(MainGameMenager.GameMenager.CheckingAnswer(_questNumber, numberSelectButton))
        {
            MainGameMenager.GameMenager.StandyMode(true, Color.green, numberSelectButton);
            Statistics.Stats.CountCorectAnswer++;
            _questNumber++;
        }
        else
        {
            MainGameMenager.GameMenager.StandyMode(true, Color.red, numberSelectButton);
            _questNumber++;
        }
    }

    public void LoadNextQuest()
    {
        if (_questNumber < MainGameMenager.GameMenager.dataFromFile.CountQuestions)
        {
            MainGameMenager.GameMenager.LoadQuest(_questNumber);
            MainGameMenager.GameMenager.StandyMode(false); 
        }
        else
        {
            Statistics.Stats.PrintStatistics();
            UIController.control.isActiveStatistics = true;
        }
    }
}
