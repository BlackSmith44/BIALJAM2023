using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Linq;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI board;
    void Start()
    {
        List<Tuple<string, int>> data = new List<Tuple<string, int>>();

        string[] lines = File.ReadAllLines("score_board.txt");

        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            if (parts.Length == 2)
            {
                string name = parts[0];
                int score = int.Parse(parts[1]);

                data.Add(Tuple.Create(name, score));
            }
        }
        string info = "";
        data.Sort((a, b) => b.Item2.CompareTo(a.Item2));
        List<Tuple<string, int>> top10Data = data.Take(10).ToList();
        for (int i = 0; i<top10Data.Count; i++)
        {
            int nr = i + 1;
            (string name, int score) = top10Data[i];
            info += nr.ToString()+"."+ "  " + name + "   "  + score.ToString() + "    " + '\n';
        }
        Debug.Log(info);
        board.text = info;
    }
}

