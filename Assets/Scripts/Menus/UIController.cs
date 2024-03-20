using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//I'll turn this into an interface and refactor this class and its children when we finish our demo!
// - Kris

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Animator SatelliteAnimator;
    [SerializeField]
    private Animator PauseMenuAnimator;
    [SerializeField]
    private Animator DialougeAnimator;
    [SerializeField]
    private Animator LevelCompleteAnimator;
    /*[SerializeField]
    private Animator LevelStartAnimator;*/

    [SerializeField]
    private GameObject SatelliteCanvas;
    [SerializeField]
    private GameObject PauseMenuCanvas;
    [SerializeField]
    private GameObject DialougeCanvas;
    [SerializeField]
    private GameObject LevelCompleteCanvas;

    //These fileds are references to dialouge text elements
    [SerializeField]
    private GameObject DialougeName;
    [SerializeField]
    private GameObject DialougeText;

    //These fields are so that we have an easy reference to the text on the satellite Canvas screen
    [SerializeField]
    private GameObject SatellitePartName;
    [SerializeField]
    private GameObject SatellitePartDesc;
    [SerializeField]
    private GameObject SatellitePartImage;
    [SerializeField]
    private GameObject SatelliteNextButton;

    [SerializeField]
    private GameObject objectiveMarker;

    [SerializeField]
    private float menuAnimationTime;

    [SerializeField]
    private GameObject gameManager;

    private bool isPaused = false;
    private bool isTalking = false;
    private NPCBehaviour currentNPC; //Holds reference to the current NPC being interacted with

    //Used to determine which item in the satellite parts menu we are currently on
    private int satelliteIndex = 0;

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Setter Methods~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

    public void setAnimationTime(float newTime) 
    { 
        menuAnimationTime = newTime; 
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Level Complete Methods~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

    public void startLevelComplete() 
    {
        objectiveMarker.SetActive(false);
        SatelliteCanvas.SetActive(false); //close satellite collect screen
        Time.timeScale = 0f;
        Debug.Log("Start");
        LevelCompleteAnimator.ResetTrigger("CompleteExitTrigger");
        //the canvas will start its animation the moment it becomes active for the first time
        LevelCompleteCanvas.SetActive(true);

        //LevelCompleteAnimator.SetTrigger("CompleteExitTrigger");
    }

    public void closeLevel()
    {
        setAnimationTime(3f);
        Time.timeScale = 1f;
        StartCoroutine(closeLevelComplete());

    }

    IEnumerator closeLevelComplete()
    {

        //Dialouge Closing Animation
        LevelCompleteAnimator.SetTrigger("CompleteExitTrigger");

        //Wait for animtation to finish
        yield return new WaitForSeconds(menuAnimationTime);

        //LevelCompleteCanvas.gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().name.Equals("Ice_Landing")) { gameManager.GetComponent<GameManager>().startNextScene("IceWorld"); }
        else if (SceneManager.GetActiveScene().name.Equals("IceWorld")) { gameManager.GetComponent<GameManager>().startNextScene("Ice_Takeoff");}
        else if (SceneManager.GetActiveScene().name.Equals("Ice_Takeoff")) { gameManager.GetComponent<GameManager>().startNextScene("Lava_Landing"); }
        else if (SceneManager.GetActiveScene().name.Equals("Lava_Landing")) { gameManager.GetComponent<GameManager>().startNextScene("LavaWorld"); }
        else if (SceneManager.GetActiveScene().name.Equals("LavaWorld")) { gameManager.GetComponent<GameManager>().startNextScene("Lava_Takeoff"); }
        else{ gameManager.GetComponent<GameManager>().startNextScene("MainMenu"); }

    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Dialouge Methods~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

    public void openDialouge(NPCBehaviour newNPC)
    {
        currentNPC = newNPC; //update NPC reference
        isTalking = true;

        objectiveMarker.SetActive(false);

        //Activate Dialouge Objects
        DialougeCanvas.gameObject.SetActive(true);

        //Start animation
        DialougeAnimator.ResetTrigger("DialougeExitTrigger");
        DialougeAnimator.SetTrigger("DialougeStartTrigger");


        //Stop game
        Time.timeScale = 0f;

    }

    public void updateDialougeBox() {

        if (currentNPC.checkDialouge())
        {
            //if there is more dialouge update the textbox
            currentNPC.setNextDialouge();
        }
        else {
            //if there is no more text, close the menu
            closeDialouge();
        }

    }

    public void setNewDialouge(string newName, string newDialouge) 
    {
        DialougeName.gameObject.GetComponent<TextMeshProUGUI>().SetText(newName);
        DialougeText.gameObject.GetComponent<TextMeshProUGUI>().SetText(newDialouge);
    }

    public void closeDialouge()
    {
        isTalking = false;
        setAnimationTime(0.3f);
        StartCoroutine(closeDialougeMenu());

        //Restart Game
        if (isPaused != true) { Time.timeScale = 1f; }
        objectiveMarker.SetActive(true);
        setAnimationTime(1f);
        Debug.Log("Closed!");
    }

    IEnumerator closeDialougeMenu()
    {

        //Dialouge Closing Animation
        DialougeAnimator.ResetTrigger("DialougeStartTrigger");
        DialougeAnimator.SetTrigger("DialougeExitTrigger");

        //Wait for animtation to finish
        yield return new WaitForSeconds(menuAnimationTime);

        DialougeCanvas.gameObject.SetActive(false);

    }


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Pause Menu Methods~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    public void openPause()
    {

        objectiveMarker.SetActive(false);

        //Activate Menu Objects
        PauseMenuCanvas.gameObject.SetActive(true);

        //Start animation
        PauseMenuAnimator.ResetTrigger("PauseExitTrigger");
        PauseMenuAnimator.SetTrigger("PauseStartTrigger");

        isPaused = true;

        //Stop game
        Time.timeScale = 0f;

    }

    public void openSettings() {
        //Start animation
        PauseMenuAnimator.ResetTrigger("SettingExitTrigger");
        PauseMenuAnimator.SetTrigger("SettingStartTrigger");
    }

    public void closeSettings()
    {
        //Start animation
        PauseMenuAnimator.SetTrigger("SettingExitTrigger");
        PauseMenuAnimator.ResetTrigger("SettingStartTrigger");
    }

    public void closePause()
    {
        //Restart Game
        PauseMenuAnimator.SetTrigger("SettingExitTrigger");
        StartCoroutine(closePauseMenu());

        isPaused = false;
        objectiveMarker.SetActive(true);
        if (isTalking != true) { Time.timeScale = 1f; }
    }

    IEnumerator closePauseMenu()
    {

        //SatelliteCollect Menu Closing Animation
        PauseMenuAnimator.ResetTrigger("PauseStartTrigger");
        PauseMenuAnimator.SetTrigger("PauseExitTrigger");

        //Wait for animtation to finish
        yield return new WaitForSeconds(menuAnimationTime);

        PauseMenuCanvas.gameObject.SetActive(false);
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Satellite Menu Methods~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
    
    public void openSatelliteCollect()
    {

        objectiveMarker.SetActive(false);
        //Activate Menu Objects
        SatelliteCanvas.gameObject.SetActive(true);

        updateSatelliteCanvas();

        //Start animation
        SatelliteAnimator.ResetTrigger("Close");
        SatelliteAnimator.SetTrigger("Start");


        //Stop game
        Time.timeScale = 0f;

    }

    public void closeSatelliteCollect()
    {

        //Restart Game
        if (isPaused != true) { Time.timeScale = 1f; }

        gameManager.GetComponent<GameManager>().checkForLevelCompletion();


        StartCoroutine(closeMenu());

    }

    IEnumerator closeMenu()
    {

        //reset index value to start at the beginning of the list next time the menu is opened
        satelliteIndex = 0;

        //SatelliteCollect Menu Closing Animation
        SatelliteAnimator.ResetTrigger("Start");
        SatelliteAnimator.SetTrigger("Close");

        //Wait for animtation to finish
        yield return new WaitForSeconds(menuAnimationTime);
        objectiveMarker.SetActive(true);
        SatelliteCanvas.gameObject.SetActive(false);
    }

    //Updates text on the satellite collect screen based on which part of parts list is being viewed
    private void updateSatelliteCanvas() { 

        List<SatellitePart> partsList = gameManager.GetComponent<GameManager>().getSatelliteParts();

        //Get reference to next button and turn if off if there is no next item
        if (gameManager.GetComponent<GameManager>().getAmountofParts() < 2) { SatelliteNextButton.gameObject.SetActive(false); }
        else { SatelliteNextButton.gameObject.SetActive(true); }

        if (partsList.Count != 0) {
            SatelliteCanvas.gameObject.SetActive(true);
            SatellitePartName.gameObject.GetComponent<TextMeshProUGUI>().SetText(partsList[satelliteIndex].getName());
            SatellitePartDesc.gameObject.GetComponent<TextMeshProUGUI>().SetText(partsList[satelliteIndex].getDescription());
            SatellitePartImage.gameObject.GetComponent<Image>().sprite = partsList[satelliteIndex].getImage();
        }

    }

    //public access method to check the next part in the parts menu
    public void updateToNextPart() {

        List<SatellitePart> partsList = gameManager.GetComponent<GameManager>().getSatelliteParts();

        satelliteIndex++;
        if (satelliteIndex >= partsList.Count) { satelliteIndex = 0; }

        updateSatelliteCanvas();

    }

}
