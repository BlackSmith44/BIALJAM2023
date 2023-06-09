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
        if (collision.gameObject.tag == "Car" && !occupied)
        {
            CarScript carScript = collision.gameObject.GetComponent<CarScript>();

            collision.gameObject.layer = 10;
            occupied = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            //occupied = false;
        }
    }



}
