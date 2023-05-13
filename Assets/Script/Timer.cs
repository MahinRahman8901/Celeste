 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float CurrentTime = 0f;
    float StartTime = 60f;
    [SerializeField] Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime; //Countdown timer takes away current time from variable set above
        countdownText.text = CurrentTime.ToString("0");

        if (CurrentTime <= 0 ){ //when the time hits zero it switches to the game over screen
            SceneManager.LoadScene(3);
        }

        else if (CurrentTime <=10){ //colour of text changes to red when timer has 10 seconds left
            countdownText.color = Color.red;
        }
    }
}
