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

    public List<Sprite> livePersons;

    public Image nationality;

    public List<Sprite> nationalityStamps;

    public CarScript cs;

    public Image personOnLive;

    public ButtonHandlerScript bh;

    public bool flag;

    Car c;
    Licence l;

    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        ClearAll();
    }

    // Update is called once per frame
    void Update()
    {
        if(cs != null && flag)
        {
            InitUIData();
            flag = false;
        }
        else if(cs == null)
        {
            ClearAll();
            flag = true;
        }
    }

    private void InitUIData()
    {

        bh.ComeBack();

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

        nationality.sprite = CheckNatioanlity();
        nationality.gameObject.SetActive(true);

        personOnLive.sprite = livePersons[c.portrait];
        personOnLive.gameObject.SetActive(true);
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

    private Sprite CheckNatioanlity()
    {

        switch(c.nationality)
        {
            case "Poland":
                {
                    return nationalityStamps[0];
                }
            case "Sweden":
                {
                    return nationalityStamps[1];
                }
            case "Czech":
                {
                    return nationalityStamps[2];
                }
            case "Norway":
                {
                    return nationalityStamps[3];
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

        nationality.gameObject.SetActive(false);

        personOnLive.gameObject.SetActive(false);
    }
}
