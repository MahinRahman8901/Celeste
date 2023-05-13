using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour
{
    public Text ScoreText;
    private int Score = 0;
    // Start is called before the first frame update

    public void Start(){

    }


    void onCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Ball"){
            Score +=1;
            ScoreText.text = Score.ToString();
            Debug.Log("Ball hit the floor. Score: " + Score);
        }
    }
}
