using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSimpleScean : MonoBehaviour
{
    public void LoadSampleScean()
    {
        SceneManager.LoadScene(6);
    }

    public void Close()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}