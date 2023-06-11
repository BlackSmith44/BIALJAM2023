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

    public RectTransform idCard;

    public float moveDuration = 1f;
    public float prizeAmount = 30f;
    public float penaltyAmount = 50;


    public Vector2 initialPosition;
    public Vector2 targetPosition;
    private float positionThreshold = 5f;
    public float distance;
    public float elapsedTime;

    public GameObject book;

    private void Start()
    {
        book.SetActive(false);
    }

    public void Accept()
    {
        if (ins.currCar != null)
        {
            CarScript cs = ins.currCar.GetComponent<CarScript>();
            if (cs.licence.isValid)
            {
                counterScript.counter += prizeAmount;
            }
            else
            {
                counterScript.counter -= penaltyAmount;
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
                counterScript.counter += prizeAmount;
            }
            else
            {
                counterScript.counter -= penaltyAmount;
            }

            cs.ReadyToLeave();
            LockButtons();
        }
    }

    public void LockButtons()
    {
        acceptButton.interactable = false;
        declineButton.interactable = false;
        //FlyAway();
        StartCoroutine(MoveUI(true));
        StartCoroutine(WaitAndPrint(3));
    }

    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        {
            acceptButton.interactable = true;
            declineButton.interactable = true;
        }

    }

    /*private void FlyAway()
    {
        while( Vector3.Distance(idCard.transform.position,endPoint.transform.position)>1f)
        {
            idCard.transform.position = Vector3.MoveTowards(idCard.transform.position, endPoint.transform.position,1);
        }
    }*/

    private System.Collections.IEnumerator MoveUI(bool flag)
    {
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            if(flag)
            {
                float t = elapsedTime / moveDuration;
                idCard.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, t);
                elapsedTime += Time.deltaTime;

                // Check if the UI component is close to the target position
                distance = Vector2.Distance(idCard.anchoredPosition, targetPosition);
                if (distance <= positionThreshold)
                {
                    idCard.anchoredPosition = targetPosition;
                    break;
                }

                yield return null;
                idCard.anchoredPosition = targetPosition;
            }
            else
            {
                float t = elapsedTime / moveDuration;
                idCard.anchoredPosition = Vector2.Lerp(targetPosition, initialPosition, t);
                elapsedTime += Time.deltaTime;

                // Check if the UI component is close to the target position
                distance = Vector2.Distance(idCard.anchoredPosition, initialPosition);
                if (distance <= positionThreshold)
                {
                    idCard.anchoredPosition = initialPosition;
                    break;
                }

                yield return null;
                idCard.anchoredPosition = initialPosition;
            }
            

        }

        //idCard.anchoredPosition = targetPosition;
    }

    public void ComeBack()
    {
        StartCoroutine(MoveUI(false));
    }

    public void OpenBook()
    {
        book.SetActive(true);
    }

    public void CloseBook()
    {
        book.SetActive(false);
    }

}
