using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Methods for controlling button actions

    //When method is invoked, changes scene to the first game scene
    public void playButton() {
        SceneManager.LoadScene("Intro");
    }

    //When method is invoked, closes the game
    public void quitButton()
    {
        Debug.Log("YOU QUIT :(");
        Application.Quit();
    }

}
