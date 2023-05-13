using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    private static int score = 0;
    private static Text scoreText;

    void Start()
    {
        if(scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();//finds the text component that will display the score
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor1") //checks if the ball has collided with the first floor that is tagged "Floor1"
        {
            Debug.Log("Floor 1");
        }
        else if(collision.gameObject.tag == "Floor2") //checks if floor 2 has been tagged
        {
            score += 1;//then adds a point to the score for each one this occurs to and stores it in the variable
            scoreText.text = score.ToString();
            
        }
    }   

    void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", score); //when the game is finished it stores the variable score so that I can use it after in the game over screen to display the score again
    }
}
