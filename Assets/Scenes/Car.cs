using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car
{
    public int TypeId;
    public Person person;
    //public Color color;
    public string carNum;
    public int[] carComponenetsl;

    public Car(int typeId, Person person, string carNum, int[] carComponenetsl)
    {
        TypeId = typeId;
        this.person = person;
        this.carNum = carNum;
        this.carComponenetsl = InitCarComponents();
    }

    public int[] InitCarComponents()
    {
        int[] carComponenetsl = new int[2];



        return carComponenetsl;
    }
}
