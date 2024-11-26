using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    
    public void GoToEasyMode()
    {
        SceneManager.LoadScene("EasyMode");
    }

    public void GotoNormalMode()
    {
        SceneManager.LoadScene("NormalMode");
    }

    public void GoToHardMode()
    {
        SceneManager.LoadScene("HardMode");
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
