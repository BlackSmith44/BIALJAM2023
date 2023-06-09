using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Car
{
    public int TypeId;
    public int portrait;
    public Licence person;
    //public Color color;
    public string carNum;
    public int[] carComponenetsl;

    public Car(int typeId, Licence person, string carNum, int[] carComponenetsl)
    {
        TypeId = typeId;
        this.person = Licence.GenerateLicence();
        this.carNum = carNum;
        this.carComponenetsl = InitCarComponents();
    }




    public int[] InitCarComponents()
    {
        int[] carComponenetsl = new int[2];

        return carComponenetsl;
    }
}
