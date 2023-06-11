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
    public string nationality;
    public int sex;

    public Car(Licence licence, int portrait, int typeId,  string carNum, string nationality, int sex)
    {
        this.licence = licence;
        this.portrait = portrait;
        this.typeId = typeId;
        this.carNum = carNum;
        this.nationality = nationality;
        this.sex = sex;
        // this.carComponenetsl = InitCarComponents();
    }

    public static Car GenerateCar()
    {
        Licence licence = Licence.GenerateLicence();

        int portrait = licence.portrait;
        int typeId = licence.typeId;
        string carNum = licence.carNum;
        string nationality = licence.nationality;
        int sex = licence.sex;
        if(!licence.isValid)
        {
            System.Random random = new System.Random();
            int randomNumber = random.Next(1, 6);
            Debug.Log(randomNumber);
            randomNumber = 5;
            switch (randomNumber)
            {
                case 1:
                    int newPortrait = -1;
                    while (newPortrait == portrait || newPortrait == -1)
                        newPortrait = random.Next(0, 10);
                    portrait = newPortrait;
                    break;
                case 2:
                    int newTypeId = -1;
                    while (newTypeId == typeId || newTypeId == -1)
                        newTypeId = random.Next(0, 3);
                    typeId = newTypeId;
                    break;

                case 3:
                    string newCarNum = null;
                    while(newCarNum == carNum || newCarNum == null)
                        newCarNum = GenerateRandomCarNumber();
                    carNum = newCarNum;
                    break;

                case 4:
                    string newNatioanlity = null;
                    while (newNatioanlity == nationality || newNatioanlity == null)
                        newNatioanlity = Licence.GenerateRandomNationality();
                    nationality = newNatioanlity;
                    break;
                case 5:
                    if (sex == 0)
                    {
                        sex = 1;
                    }
                    else
                    {
                        sex = 0;
                    }
                    break;
            }
        }
  

        return new Car(licence, portrait, typeId, carNum, nationality, sex);

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
