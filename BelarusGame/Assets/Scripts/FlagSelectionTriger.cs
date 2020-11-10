using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlagSelectionTriger : MonoBehaviour
{
    public static Vector3 startCarPos { get; set; }
    private static int flagNumber { get; set; }
    private GameObject viewButton;
    private Text textButton;

    private void Awake()
    {
        viewButton = GameObject.Find("LoadViewScean");
        textButton = viewButton.transform.Find("Text").GetComponent<Text>();
    }

    private void Start()
    {
        viewButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        flagNumber = Convert.ToInt32(gameObject.name[name.Length - 1].ToString());
        textButton.text = gameObject.tag;
        viewButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        viewButton.SetActive(false);
    }
    
    public void LoadSelectScean()
    {
        startCarPos = GameObject.Find("Car").transform.position;
        SceneManager.LoadScene(flagNumber);
    }
}
