using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider FillBar;
    public float LoadingSpeed;


    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {

        AsyncOperation manager = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);
        while(!manager.isDone)
        {
            FillBar.value = manager.progress/LoadingSpeed;
            yield return null;
        }
    }
}
