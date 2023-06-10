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

    private void Start()
    {
        panel.SetActive(true);
    }

    public void InitClear()
    {
        foreach (Transform t in queue)
        {
            t.GetComponent<CarScript>().ReadyToLeave();
            Destroy(t);
        }

        ls.ClearAll();
        
        carsapwner.SetActive(false);

        ds.isDay = true;

        scores.Add(cs.counter);

        cs.counter = 100f;
    }

    public void NextDay()
    {
        ds.isDay = true;
        carsapwner.SetActive(true);
        panel.SetActive(false);
    }

}
