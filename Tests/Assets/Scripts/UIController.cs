using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _statisticsPanel;

    public bool isActiveMainMenu { set { _mainMenuPanel.SetActive(value); } }
    public bool isActiveStatistics { set { _statisticsPanel.SetActive(value); } }

    public static UIController control;

    private void Awake()
    {
        control = this;
    }

    public void ReturnToMainMenu()
    {
        isActiveMainMenu = true;
        MainGameMenager.GameMenager.LoadQuest(0);
    }

    public void RepeatQuiz()
    {
        MainGameMenager.GameMenager.LoadQuest(0);
        MainGameMenager.GameMenager.StandyMode(false);
        SelectAnswerEvent._questNumber = 0;
        Statistics.Stats.ResetStat();
        isActiveStatistics = false;
    }
}
