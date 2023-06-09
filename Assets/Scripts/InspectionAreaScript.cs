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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Car" && !occupied)
        {
            occupied = true;
            CarScript carScript = collision.gameObject.GetComponent<CarScript>();
            carScript.ias = this.GetComponent<InspectionAreaScript>();
            collision.gameObject.layer = 10;

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
