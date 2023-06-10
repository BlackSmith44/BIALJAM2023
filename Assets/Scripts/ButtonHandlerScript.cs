using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public InspectionAreaScript ins;
    public CounterScript counterScript;
    public Button acceptButton;
    public Button declineButton;

    public GameObject idCard;
    public GameObject endPoint;

    public void Accept()
    {   
        if(ins.currCar != null)
        {
            CarScript cs = ins.currCar.GetComponent<CarScript>();
            if (cs.licence.isValid)
            {
                counterScript.counter++;
            }
            else
            {
                counterScript.counter--;
            }

            cs.ReadyToLeave();
            LockButtons();
        }
    }

    public void Decline()
    {
        if (ins.currCar != null)
        {
            CarScript cs = ins.currCar.GetComponent<CarScript>();
            if (!cs.licence.isValid)
            {
                counterScript.counter++;
            }
            else
            {
                counterScript.counter--;
            }

            cs.ReadyToLeave();
            LockButtons();
        }
    }

    public void LockButtons()
    {
        acceptButton.interactable = false;
        declineButton.interactable = false;
        FlyAway();
        StartCoroutine(WaitAndPrint(5));
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        {
            acceptButton.interactable = true;
            declineButton.interactable = true;
        }

    }

    private void FlyAway()
    {
        while( Vector3.Distance(idCard.transform.position,endPoint.transform.position)>1f)
        {
            idCard.transform.position = Vector3.MoveTowards(idCard.transform.position, endPoint.transform.position,1);
        }
    }

}
