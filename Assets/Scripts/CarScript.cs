using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 direction;
    private float defaultVelocity = 0.15f;
    public bool ready;
    public InspectionAreaScript ias;
    public List<GameObject> carModels;
    public Car car;
    public Licence licence;
    public int carType;

     

    void Start()
    {
        foreach (GameObject model in carModels)
        {
            model.SetActive(false);
        }
        rb = GetComponent<Rigidbody>();
        direction = -transform.forward.normalized * defaultVelocity;
        ready = false;
        car = Car.GenerateCar();
        licence = car.licence;


        carModels[car.typeId].SetActive(true);

        CheckCar();
        CheckLicence();
    }

    void FixedUpdate()
    {
        rb.AddForce (direction,ForceMode.Impulse);
        Debug.DrawRay(transform.position,direction,Color.green);
        if(ready)
        {
            ReadyToLeave();
            ready = false; ;
        }

        foreach (Transform g in transform.GetComponentsInChildren<Transform>())
        {
            g.gameObject.layer = this.gameObject.layer;
        }

        carType = car.typeId;
    }

    public void InitDefaultVel()
    {
        direction = -transform.forward.normalized * defaultVelocity;
    }

    public void ReadyToLeave()
    {
        if(ias != null)
        {
            ias.currCar = null;
            ias.occupied = false; 
        }
        this.gameObject.layer = 7;
        StartCoroutine(WaitAndPrint(5));
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        QueueHandler qh = transform.parent.GetComponent<QueueHandler>();
        qh.queue.RemoveAt(0);
        Destroy(this.gameObject);
    }

    void CheckLicence()
    {
        if(licence != null)
        {
            Debug.Log("Person:"+"\n"+ licence.name + "\n" + licence.surname + "\n" + licence.nationality + "\n" + licence.sex + "\n" + licence.portrait + "\n" + licence.isValid + "\n" + licence.carNum);
        }
    }

    void CheckCar()
    {
        if(car != null)
        {
            Debug.Log("Car:" + "\n" + car.carNum + "\n" + car.portrait + "\n" + car.typeId);

        }
    }
}
