using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if(panel.activeSelf)
        {
            carsapwner.SetActive(false);
        }
    }

    public void InitClear()
    {

        foreach (Transform child in queue)
        {
            child.GetComponent<CarScript>().KillMe();
        }

        ls.ClearAll();
        
        ds.isDay = true;

        scores.Add(cs.counter);

        cs.counter = 100f;

        bhs.LockButtons();

        ins.occupied = false;
    }

    public void NextDay()
    {
        InitClear();
        ds.isDay = true;
        panel.SetActive(false);
        carsapwner.SetActive(true);
        ds.dayCounter++;
    }

}
