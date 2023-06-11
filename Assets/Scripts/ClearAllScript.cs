using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearAllScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform queue;

    public LicenceScript ls;

    public CounterScript cs;

    public DayTimeScript ds;

    public GameObject carsapwner;

    public List<float> scores = new List<float>();

    public GameObject panel;

    public ButtonHandlerScript bhs;

    public InspectionAreaScript ins;

    public List<GameObject> daysLeft;

    public TextMeshProUGUI scoreText;

    public GameObject yourName;

    public TextMeshProUGUI finalScore;

    public GameObject gameOverPanel;

    

    private void Start()
    {
        panel.SetActive(false);

        foreach (GameObject go in daysLeft)
        {
            go.SetActive(false);
        }

        yourName.SetActive(false);

        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if(panel.activeSelf)
        {
            ins.occupied = false;
            KillEmAll();
            carsapwner.SetActive(false);
        }

        scoreText.text = cs.counterRounded.ToString();

        int i = ds.dayCounter;

        foreach(GameObject go in daysLeft) 
        {
            if(i>0)
            {
                go.SetActive(true);
                i--;
            }
        }
    }

    public void InitClear()
    {

        ls.ClearAll();
        
        ds.isDay = true;

        scores.Add(cs.counter);

        ds.totalScore += cs.counterRounded;
        cs.counter = 100f;
        
        bhs.LockButtons();

    }

    public void KillEmAll()
    {
        foreach (Transform child in queue)
        {
            child.GetComponent<CarScript>().KillMe();
        }
    }

    public void OkAtTheEnd()
    {
        ds.SaveScore();
    }

    public void NextDay()
    {
        InitClear();
        ds.isDay = true;
        panel.SetActive(false);
        carsapwner.SetActive(true);
        if(ds.dayCounter == 5)
        {
            if(ds.totalScore>0)
            {
                yourName.SetActive(true);
                finalScore.text = ds.totalScore.ToString();
            }
            else
            {
                gameOverPanel.SetActive(true);
            }

        }
        else
        {
            ds.dayCounter++;
        }
    }

}