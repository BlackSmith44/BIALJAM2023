using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class Licence 
{
    public int portrait;
    public string name;
    public string surname;
    public int sex;
    public string nationality;
    public string carNum;
    public int typeId;
    public bool isValid;


    public Licence(int portrait, string name, string surname, int sex, string nationality, string carNum, int typeId, bool isValid = true)
    {
        this.portrait = portrait;
        this.name = name;
        this.surname = surname;
        this.sex = sex;
        this.nationality = nationality;
        this.carNum = carNum;
        this.typeId = typeId;
        this.isValid = isValid;
    }


    public static Licence GenerateLicence()
    {
        System.Random random = new System.Random();
        int portrait = random.Next(1, 10);
        string name = GenerateRandomName();
        string surname = GenerateRandomSurname();
        int sex = random.Next(0, 2); // 0 for male, 1 for female
        string nationality = GenerateRandomNationality();
        string carNum = GenerateRandomCarNumber();
        int typeId = random.Next(0, 3);
        bool isValid = GenerateIsValid(0.75);

        return new Licence(portrait, name, surname, sex, nationality, carNum, typeId, isValid);
    }

    private static string GenerateRandomName()
    {
        System.Random random = new System.Random();
        List<string> NameList = new List<string>(){
            "LucyAshton",
                "Michelle",
                "Rebecca",
                "Sarah",
                "Carina",
                "Emily",
                "Sarah",
                "Nicol",
                "Fenton",
                "Nicholas",
                "Robert",
                "Kelsey",
                "Amanda",
                "Adison",
                "April",
                "Marcus",
                "Myra",
                "Dexter",
                "Maximilian",
                "Ted",
                "Alberta",
                "Eric",
                "Tess",
                "William",
                "Roman",
                "Amber",
                "Lily",
                "Tiana",
                "Amanda",
                "Olaf" };

        int index = random.Next(0, NameList.Count);
        return NameList[index];
    }

    private static string GenerateRandomSurname()
    {
        System.Random random = new System.Random();
        List<string> SurnameList = new List<string>(){
            "Nelson",
            "Phillips",
            "Kelley",
            "Cunningham",
            "Murphy",
            "Ellis",
            "Higgins",
            "Rogers",
            "Cunningham",
            "Stewart",
            "Cunningham",
            "Thomas",
            "Turner",
            "Hunt",
            "Turner",
            "Allen",
            "Robinson",
            "Campbell",
            "Moore",
            "Kelly",
            "Jones",
            "Allen",
            "Sullivan",
            "Rogers",
            "Barrett",
            "Crawford",
            "Thomas",
            "Myers",
            "Brown",
            "Wilson"};
        int index = random.Next(0, SurnameList.Count);
        return SurnameList[index];
    }

    private static string GenerateRandomNationality()
    {
        System.Random random = new System.Random();
        List<string> NationalityList = new List<string>(){
            "Poland",
            "Sweden",
            "Germany",
            "Norway" };

        int index = random.Next(0, NationalityList.Count);
        return NationalityList[index];
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
    private static bool GenerateIsValid(double weight)
    {
        System.Random random = new System.Random();
        double randomValue = random.NextDouble();

        if (randomValue < weight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
