using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class Car
{
    public int typeId;
    public int portrait;
    public Licence licence;
    //public Color color;
    public string carNum;
    public int[] carComponenetsl;

    public Car(Licence licence, int portrait, int typeId,  string carNum)
    {
        this.licence = licence;
        this.portrait = portrait;
        this.typeId = typeId;
        this.carNum = carNum;
        // this.carComponenetsl = InitCarComponents();
    }

    public static Car GenerateCar()
    {
        Licence licence = Licence.GenerateLicence();
        int portrait = licence.portrait;
        int TypeId = licence.typeId;
        string carNum = licence.carNum;

        if(!licence.isValid)
        {
            System.Random random = new System.Random();
            int randomNumber = random.Next(1, 4);
            switch (randomNumber)
            {
                case 1:
                    portrait = random.Next(1, 100);
                    break;
                case 2:
                    portrait = random.Next(1, 3);
                    break;
                case 3:
                    carNum = GenerateRandomCarNumber();
                    break;
            }
        }
  

        return new Car(licence, portrait, TypeId, carNum);

    }

    private static string GenerateRandomCarNumber()
    {
        System.Random random = new System.Random();
        StringBuilder letters = new StringBuilder();
        for (int i = 0; i < 3; i++)
        {
            char randomLetter = (char)random.Next('A', 'Z' + 1);
            letters.Append(randomLetter);
        }

        StringBuilder digits = new StringBuilder();
        for (int i = 0; i < 3; i++)
        {
            int randomDigit = random.Next(0, 10);
            digits.Append(randomDigit);
        }

        string result = letters.ToString() + digits.ToString();
        return result;
    }

    public int[] InitCarComponents()
    {
        int[] carComponenetsl = new int[2];

        return carComponenetsl;
    }
}
