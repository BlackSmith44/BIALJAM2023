using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DayTimeScript : MonoBehaviour
{
    public GameObject Sun;
    public float duration = 3f;
    public float frameTime;
    public float step = 0.5f;
    public bool isDay = true;
    public GameObject panel;
    public TMP_InputField playerName;
    public CounterScript Score;
    public int dayCounter = 1;
    public string filePath = "score_board.txt";
    public bool gameRuning = true;

    public int totalScore;

    void Start()
    {
        totalScore = 0;
        frameTime = 0;
    }
    void Update()
    {
        
        if (frameTime <= duration & isDay && gameRuning==true)
        {
            frameTime += Time.deltaTime;
        }
        else if(isDay & frameTime >= duration && gameRuning == true)
        {
            Sun.transform.Rotate(step, 0f, 0f);
            if (Sun.transform.eulerAngles[0] >= 200)
            {
               
                isDay = false;
               
                Sun.transform.eulerAngles = new Vector3(0, 0f, 0f);

            }
            frameTime = 0;
        }
        else if(!isDay)
        {
            panel.SetActive(true);
            if (dayCounter == 5 && gameRuning==true)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(playerName.text.ToString() + " " + totalScore.ToString() + "\n");
                    gameRuning = false;
                }
            }
        }

    }

}
