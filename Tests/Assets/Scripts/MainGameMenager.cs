using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainGameMenager : MonoBehaviour, IPointerClickHandler
{
    private QuestionsMenager questionsMenager;
    public Text[] QestAndAnswer;
    private static int[] randomNumbersArray;
    private int randomNumber;
    private int numberSelectButton;

    private void Start()
    {
        questionsMenager = new QuestionsMenager();
        questionsMenager.LoadQuest(QestAndAnswer, GenerateRandomNumber());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject selectButton = eventData.pointerCurrentRaycast.gameObject;
        numberSelectButton = Convert.ToInt32(selectButton.tag);
        questionsMenager.LoadQuest(QestAndAnswer, GenerateRandomNumber());

        if(questionsMenager.CheckingAnswer(randomNumber, numberSelectButton))
        {
            selectButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            selectButton.GetComponent<Image>().color = Color.green;
        }
    }

    //TODO: Здесь БАГ
    private int GenerateRandomNumber()
    {
        randomNumbersArray = new int[questionsMenager.CountQuest];
        randomNumber = UnityEngine.Random.Range(0, questionsMenager.CountQuest);

        while (randomNumbersArray.Contains(randomNumber))
        {
            randomNumber = UnityEngine.Random.Range(0, questionsMenager.CountQuest);
            randomNumbersArray[randomNumbersArray.Length] = randomNumber;
        }

        return randomNumber;
    }
}