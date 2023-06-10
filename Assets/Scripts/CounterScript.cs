using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    // Start is called before the first frame update

    public InspectionAreaScript inspetionArea;
    TextMeshProUGUI text;
    public float counter;
    public bool CarLeaving = false;
    public bool occupied;
    public int counterRounded;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        counter = 100f;
        text.text = "";
        counterRounded = 100;
    }

    // Update is called once per frame
    void Update()
    {
        occupied = inspetionArea.occupied;
        if (occupied)
        {
            counter = counter - Time.deltaTime;

        }

        counterRounded = Mathf.RoundToInt(counter);
        text.text = counterRounded.ToString();
    }
}