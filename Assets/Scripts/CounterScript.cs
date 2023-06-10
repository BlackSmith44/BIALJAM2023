using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshProUGUI text;
    public float counter;
    public float totalScore = 0;
    public InspectionAreaScript Inspection;
    public bool isOccupied = false;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        counter = 100f;
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(Inspection.occupied == true && isOccupied == false)
        {
            counter = counter - Time.deltaTime;
            text.text = totalScore.ToString();
        }
        if(Inspection.occupied == true && isOccupied == true)
        {
            isOccupied = false;
        }

           
    }
}
