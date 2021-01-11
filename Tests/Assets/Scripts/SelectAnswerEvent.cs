using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectAnswerEvent : MonoBehaviour, IPointerClickHandler
{
    private QuestionsMenager questionsMenager;
    private int numberSelectButton;
    private GameObject selectButton;
    private int _questNumber;

    private void Start()
    {
        _questNumber = 0;
        questionsMenager = new QuestionsMenager();
        MainGameMenager.GameMenager.LoadQuest(questionsMenager, _questNumber);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selectButton = eventData.pointerCurrentRaycast.gameObject;
        numberSelectButton = Convert.ToInt32(selectButton.tag);

        if(questionsMenager.CheckingAnswer(_questNumber, numberSelectButton))
        {
            gameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }
}
