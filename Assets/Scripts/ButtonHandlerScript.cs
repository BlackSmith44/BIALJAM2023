using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public InspectionAreaScript ins;
    public CounterScript counterScript;
    public Button acceptButton;
    public Button declineButton;

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

        StartCoroutine(WaitAndPrint(2));
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        {
            acceptButton.interactable = true;
            declineButton.interactable = true;
        }

    }

}
