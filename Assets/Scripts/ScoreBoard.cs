using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    //PlayerScore();
}


public class PlayerScore
{
    public string name;
    public int score = 0 ;
    public int dayPassed = 0;
   
    PlayerScore(string name, int score, int dayPassed)
    {
        this.name = name;
        this.score = score;
        this.dayPassed = dayPassed;
    }

}
