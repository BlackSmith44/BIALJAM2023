using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayTimeScript : MonoBehaviour
{
    public GameObject Sun;
    public float duration = 3f;
    public float frameTime;
    public float step = 0.5f;
    public bool isDay = true;

    public int dayCounter = 0;


    void Start()
    {
        frameTime = 0;
    }
    void Update()
    {
        if (frameTime <= duration & isDay)
        {
            frameTime += Time.deltaTime;
        }
        else if(isDay)
        {
            Sun.transform.Rotate(step, 0f, 0f);
            if (Sun.transform.eulerAngles[0] >= 170)
            {
                isDay = false;
                dayCounter++;
                Sun.transform.eulerAngles = new Vector3(0, 0f, 0f);
            }
            frameTime = 0;
        }
    }


    public void Night()
    {
        Debug.Log("change to night");
    }

}