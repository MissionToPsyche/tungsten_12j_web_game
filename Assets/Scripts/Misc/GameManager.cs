using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //Reference to Canvas
    [SerializeField]
    private GameObject UIController;

    [SerializeField]
    private GameObject Player;

    //List of all parts collected
    static private List<SatellitePart> Parts = new List<SatellitePart>();

    void Start()
    {
        //renews part list at beginning of game
        if (SceneManager.GetActiveScene().name.Equals("IceWorld")) {
            Parts = new List<SatellitePart>();
            Debug.Log("Parts list cleared!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {

            Player.GetComponent<PlayerSFX>().stopStep(); //stop walking sfx
            
            UIController.GetComponent<UIController>().openPause();
        }

    }

    public List<SatellitePart> getSatelliteParts() {
        return Parts;
    }

    public int getAmountofParts() {
        return Parts.Count;
    }

    public void setNewSatellitePart(SatellitePart newPart) {
        Parts.Insert(0, newPart);
    }

    public void checkForLevelCompletion() {
        //If the all the parts in a level have been collected, start level complete animation
        if ((Parts.Count >= 3) &&
            (SceneManager.GetActiveScene().name.Equals("IceWorld")))
        {
            startNextScene("Ice_Takeoff");
            //UIController.GetComponent<UIController>().startLevelComplete();
        }
        else if ((Parts.Count >= 6) &&
            (SceneManager.GetActiveScene().name.Equals("LavaWorld"))) 
        { 
            startNextScene("Lava_Takeoff"); 
        }
    }

    public void startNextScene(string levelName) {
        Debug.Log("Onto the next one!");
        SceneManager.LoadScene(levelName);
    }

}
