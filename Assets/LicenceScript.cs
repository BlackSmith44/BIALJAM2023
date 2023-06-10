using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LicenceScript : MonoBehaviour
{
    public List<TextMeshProUGUI> bulletedTextList;

    public List<GameObject> carTypeCheckList;

    public Image portrait;

    public List<Sprite> portraitsList;

    public TextMeshProUGUI nationality;

    public CarScript cs;

    Car c;
    Licence l;

    // Start is called before the first frame update
    void Start()
    {
        ClearAll();
    }

    // Update is called once per frame
    void Update()
    {
        if(cs != null)
        {
            InitUIData();
        }
        else
        {
            ClearAll();
        }
    }

    private void InitUIData()
    {
        c = cs.car;
        l = c.licence;
        bulletedTextList[0].text = l.name;
        bulletedTextList[1].text = l.surname;
        bulletedTextList[2].text = CehckSex(l.sex);
        bulletedTextList[3].text = l.nationality;
        bulletedTextList[4].text = l.carNum;

        portrait.sprite = portraitsList[l.portrait];

        carTypeCheckList[l.typeId].SetActive(true);
        portrait.gameObject.SetActive(true);
    }


    private string CehckSex(int i)
    {
        if(i == 1)
        {
            return "Male";
        }
        else if(i == 0)
        {
            return "Female";
        }
        else
        { 
            return null; 
        }
    }

    private string CheckNatioanlity()
    {

        switch(l.nationality)
        {
            case "Poland":
                {
                    return "PL";
                }
            case "Sweden":
                {
                    return "S";
                }
            case "Germany":
                {
                    return "D";
                }
            case "Norway":
                {
                    return "N";
                }

        }

        return null;
    }

    private void ClearAll()
    {

        foreach(var item in bulletedTextList)
        {
            item.text = null;
        }

        foreach (var item in carTypeCheckList)
        {
            item.SetActive(false);
        }

        portrait.gameObject.SetActive(false);

        nationality.text = null;
    }
}
