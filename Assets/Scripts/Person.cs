using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{

    public int portrait;
    public string name;
    public string surname;
    public int sex;
    public string nationality;
    public string carNum;
    public bool isValid;


    public Person(int portrait, string name, string surname, int sex, string nationality, string carNum, bool isValid = true)
    {
        this.portrait = portrait;
        this.name = name;
        this.surname = surname;
        this.sex = sex;
        this.nationality = nationality;
        this.carNum = carNum;
        this.isValid = isValid;
    }


}
