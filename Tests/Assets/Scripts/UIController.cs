using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Inspector
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _statisticsPanel;
    [SerializeField] private GameObject _pathInputPanel;
    [SerializeField] private GameObject _pathInputField;
    [SerializeField] private Text _themText;
    #endregion

    public bool IsActiveMainMenu { set { _mainMenuPanel.SetActive(value); } }
    public bool IsActiveStatistics { set { _statisticsPanel.SetActive(value); } }
    public bool IsActivePathPanel { set { _pathInputPanel.SetActive(value); } }

    public static UIController control;

    private void Awake()
    {
        control = this;
    }

    public void StartQuiz()
    {
        IsActiveMainMenu = false;
        IsActiveStatistics = false;
        MainGameMenager.GameMenager.StandyMode(false);
        SelectAnswerEvent._questNumber = 0;
        Statistics.Stats.ResetStat();
    }

    public void ReturnToMainMenu()
    {
        IsActiveMainMenu = true;
        IsActiveStatistics = false;
        MainGameMenager.GameMenager.LoadQuest(0);
    }

    public void RepeatQuiz()
    {
        MainGameMenager.GameMenager.LoadQuest(0);
        MainGameMenager.GameMenager.StandyMode(false);
        SelectAnswerEvent._questNumber = 0;
        Statistics.Stats.ResetStat();
        IsActiveStatistics = false;
        IsActiveMainMenu = false;
    }

    public void ExitApplications()
    {
        Application.Quit();
    }

    public void LoadFile()
    {
        InputField inputField = _pathInputField.GetComponent<InputField>();
        string path = inputField.text;

        if (File.Exists(path))
        {
            MainGameMenager.GameMenager.dataFromFile.FormattingFilleData(path);
            MainGameMenager.GameMenager.LoadQuest(0);
            _pathInputField.GetComponent<Image>().color = Color.green;
            _themText.text = $"QUIZ\n{MainGameMenager.GameMenager.dataFromFile.ThemeText}";
        }
        else
        {
            _pathInputField.GetComponent<Image>().color = Color.red;
        }
    }

    public void ExitFromPathPanel()
    {
        _pathInputField.GetComponent<Image>().color = Color.white;
        _pathInputField.GetComponent<InputField>().text = "";
        IsActivePathPanel = false;
    }
}
