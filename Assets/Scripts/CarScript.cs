using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public List<GameObject> motors;
    public List<GameObject> cars;
    public List<GameObject> trucks;

    public List<List<GameObject>> vehicleTypes;

    private Rigidbody rb;
    public Vector3 direction;
    private float defaultVelocity = 0.15f;
    public bool ready;
    public InspectionAreaScript ias;
    public Car car;
    public Licence licence;
    public int carType;
    public LicenceScript ls;
    public bool needSlow;

    public float smoothTime;
    Vector3 zeroVelocity = Vector3.zero;
    private Vector3 smoothVelocity;

    public List<TextMeshProUGUI> licencePlates;

    public bool isValid;

     

    void Start()
    {
        vehicleTypes = new List<List<GameObject>> { motors, cars, trucks };

        foreach (List<GameObject> model in vehicleTypes)
        {
            foreach (GameObject type in model)
            {
                type.SetActive(false);
            }
        }

        foreach (var item in licencePlates)
        {
            item.text = null;
        }
        rb = GetComponent<Rigidbody>();
        direction = -transform.forward.normalized * defaultVelocity;
        ready = false;
        car = Car.GenerateCar();
        licence = car.licence;

        DrawVehicle(vehicleTypes[car.typeId]).SetActive(true);


        needSlow = false;
        smoothTime = 0.3f;

        //CheckCar();
        //CheckLicence();
    }

    void FixedUpdate()
    {
        //DrawVehicle(vehicleTypes[car.typeId]).SetActive(true);
        rb.AddForce (direction,ForceMode.VelocityChange);
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

        foreach (var item in licencePlates)
        {
            item.text = car.carNum;
        }

        if(needSlow)
        {
            Vector3 zeroVelocity = Vector3.zero;
            rb.velocity = Vector3.SmoothDamp(rb.velocity, zeroVelocity, ref smoothVelocity, smoothTime);
        }

        isValid = car.licence.isValid;
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
            if(ls != null)
            {
                ls.cs = null;
            }
        }
        this.gameObject.layer = 7;
        needSlow = false;
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

    private GameObject DrawVehicle(List<GameObject> list)
    {
        GameObject vehicle;
        if (licence.portrait == 3)
        {
            vehicle = list[2];
            return vehicle;
        }
        vehicle = list[Random.Range(0, list.Count)];
        return vehicle;
    }

}
