using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive uDPReceive;
    public GameObject[] HandPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = uDPReceive.data;  //Stores coords into the the variable to then be used 
       
        data = data.Remove(0, 1);               //This converts data into a string by removing the string characters and isolating the  numbebr itself
        data = data.Remove(data.Length-1, 1);
        
        string[] hand_point = data.Split(","); //splits the data whenever there is a comma

        for (int i = 0; i<21; i++)
        {
            float x = float.Parse(hand_point[i*3])/90;
            float y = float.Parse(hand_point[i*3+1])/90;
            float z = float.Parse(hand_point[i*3+2])/90;

            HandPoints[i].transform.localPosition = new Vector3 (x,y,z); //Maps the spheres in the hand to each x y z point so thhat movement is smooth

        }


        

    }
}
