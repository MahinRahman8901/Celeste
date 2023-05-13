using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionDetector : MonoBehaviour
{
    // Start is called before the first frame update

    WebCamTexture _webCamTexture;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices; //lists all the webcams devices

        _webCamTexture = new WebCamTexture(devices[0].name); //selects the primary webcam used by user
        _webCamTexture.Play(); //then displays this webcam on screen if needed

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = _webCamTexture; //updates the webcam
    }
}
