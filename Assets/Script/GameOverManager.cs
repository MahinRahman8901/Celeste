using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
   public void RestartButtoon()

    {
        SceneManager.LoadScene(2);
    }



    public void ExitButton()

    {
        SceneManager.LoadScene(1);
    }

}

