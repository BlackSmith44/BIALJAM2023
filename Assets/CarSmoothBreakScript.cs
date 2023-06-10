using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSmoothBreakScript : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "CarBack" || other.tag == "InspectionArea")
        {
            transform.parent.gameObject.GetComponent<CarScript>().needSlow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CarBack")
        {
            transform.parent.gameObject.GetComponent<CarScript>().needSlow = false;
        }
    }
}
