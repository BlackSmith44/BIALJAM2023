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

    Car car;
    Licence licence;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = -transform.forward.normalized * defaultVelocity;
        ready = false;
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
    }

    public void InitDefaultVel()
    {
        direction = -transform.forward.normalized * defaultVelocity;
    }

    public void ReadyToLeave()
    {
        if(ias != null)
        {
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
            Debug.Log(licence.name);
            Debug.Log(licence.surname);
            Debug.Log(licence.nationality);
            Debug.Log(licence.sex);
            Debug.Log(licence.portrait);
        }
    }
}
