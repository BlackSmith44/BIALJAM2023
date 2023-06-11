using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CarSpawnerScript : MonoBehaviour
{

    public float elapsedTime;
    public float counter;
    private float curDurration;
    private float maxCars = 10;
    public float currNumberOfCars;
    //private bool ready = false;

    public Transform queue;


    public GameObject carPrefab;
    private void Start()
    {
        curDurration = Random.Range(5, 7);
    }

    private void Update()
    {
        QueueHandler qh = queue.GetComponent<QueueHandler>();

        currNumberOfCars = queue.childCount;

        if (elapsedTime <= curDurration)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            if(currNumberOfCars<maxCars)
            {
                counter++;
                GameObject newObj = Instantiate(carPrefab, queue);
                newObj.transform.position = this.transform.position;
                curDurration = Random.Range(5, 7);
                elapsedTime = 0;
                qh.queue.Add(newObj);
            }
        }
    }
}
