using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject credits;
    public GameObject score;

    private void Start()
    {
        credits.SetActive(false);
        score.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void OpenScore()
    {
        score.SetActive(true);
    }

    public void CloseScore()
    {
        score.SetActive(false);
    }

}
