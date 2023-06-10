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
        int portrait = random.Next(0, 10);
        if (portrait == 3)
        {
            return new Licence(3, "Olaf", "Rune", 0, "Sweden", GenerateRandomCarNumber(), 2, true);
        }
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
                "Janusz",
                "Krzysiek",
                "�ukasz",
                "Micha�",
                "Natalia",
                "Jakub",
                "Marcin",
                "Arkadiusz",
                "Marcel",
                "Gra�yna",
                "Helena",
                "Maria",
                "D�esika",
                "Zofia",
                "Anna",
                "Adrian",
                "Andrzej",
                "Sebastian",
                "Piotr",
                "Pawe�",
                "Dawid",
                "Krystian",
                "Miko�aj",
                "Stefan",
                "Emanuel",
                "Ryszard",
                "Lech",
                "Fiodor",
                "Brajan",
                "Bartosz",
                "Bartosz",
                "Wojciech"};

        int index = random.Next(0, NameList.Count);
        return NameList[index];
    }

    private static string GenerateRandomSurname()
    {
        System.Random random = new System.Random();
        List<string> SurnameList = new List<string>(){
            "Nowak",
            "Kowalski",
            "Kowalczuk",
            "Kowalczyk",
            "G�rski",
            "Kosmaty",
            "Wysocki",
            "Ko�odziej",
            "Twardowski",
            "Jasi�ski",
            "Laskowski",
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
            "Wilson",
            "Adamczyk"};
        int index = random.Next(0, SurnameList.Count);
        return SurnameList[index];
    }

    public static string GenerateRandomNationality()
    {
        System.Random random = new System.Random();
        List<string> NationalityList = new List<string>(){
            "Poland",
            "Sweden",
            "Czech",
            "Norway",
            "Bulgaria",
            "Belarus",
            "Lithuania",
            "Finland",
            "Denmark",
            "Croatia",
        };

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
