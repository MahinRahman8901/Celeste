using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsGameOver : MonoBehaviour

{
    public Text scoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0); //Receives the points from main game  and stores it in variable score
        scoreText.text = "Total Points: " + score.ToString();//displays the score in the string positon
    }
}


