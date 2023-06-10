using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class InspectionAreaScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool occupied;
    public GameObject currCar;
    public LicenceScript ls;

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
            carScript.ls = ls;
            collision.gameObject.layer = 10;
            currCar = collision.gameObject;
            ls.cs = carScript;
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
