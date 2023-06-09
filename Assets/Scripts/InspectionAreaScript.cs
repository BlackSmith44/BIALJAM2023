using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionAreaScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool occupied;

    void Start()
    {
        occupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Debug.Log("Car");
        }
    }



}
