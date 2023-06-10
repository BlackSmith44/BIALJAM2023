using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CarSpawnerScript : MonoBehaviour
{

    public float elapsedTime;
    public float counter;
    private float curDurration;
    //private bool ready = false;

    public Transform queue;


    public GameObject carPrefab;
    private void Start()
    {
        curDurration = Random.Range(5, 15);
    }

    private void Update()
    {
        QueueHandler qh = queue.GetComponent<QueueHandler>();

        if (elapsedTime <= curDurration)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            //ready = false;
            counter++;          
            GameObject newObj =  Instantiate(carPrefab,queue);
            newObj.transform.position = this.transform.position;
            curDurration = Random.Range(5, 15);
            elapsedTime = 0;
            qh.queue.Add(newObj);

        }
    }
}
