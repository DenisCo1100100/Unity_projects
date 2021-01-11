using UnityEngine;
using UnityEngine.UI;

public class MainGameMenager : MonoBehaviour
{
    public static MainGameMenager GameMenager { get; private set; }
    public Text[] QestAndAnswer;

    private void Awake()
    {
        GameMenager = this;
    }

    public void LoadQuest(QuestionsMenager questions, int questNumber) 
    {
        questions.LoadQuest(QestAndAnswer, questNumber);
    }
}