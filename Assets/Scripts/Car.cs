using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Car
{
    public int TypeId;
    public int portrait;
    public Person person;
    //public Color color;
    public string carNum;
    public int[] carComponenetsl;

    public Car(int typeId, Person person, string carNum, int[] carComponenetsl)
    {
        TypeId = typeId;
<<<<<<< HEAD
        this.person = Person.GeneratePerson();
=======
        this.person = Person.GeneratePerson(); ;
>>>>>>> 58b7fb63f00969498b8b0cf04e57837d26ae07c7
        this.carNum = carNum;
        this.carComponenetsl = InitCarComponents();
    }




    public int[] InitCarComponents()
    {
        int[] carComponenetsl = new int[2];

        return carComponenetsl;
    }
}
