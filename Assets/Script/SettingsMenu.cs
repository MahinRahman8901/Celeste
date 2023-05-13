using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer MainMixer;

    // Start is called before the first frame update
    public void ChangeFullscreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen; //Changes resolution to full screen

    }

    public void ChangeQuality(int qualityvalue){
        QualitySettings.SetQualityLevel(qualityvalue); //Accesses quality settings and allows user to change the settings in the dropdown
    }

    public void changeVolume(float volume){
        MainMixer.SetFloat("Volume", volume); //Allows user to change the volume and it affects the mixer tagged "volume"

    }
}
