using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshProUGUI text;
    public int counter;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        counter = 0;
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = counter.ToString();
    }
}
