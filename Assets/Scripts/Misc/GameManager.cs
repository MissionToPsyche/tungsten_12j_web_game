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

    //List of all parts collected
    static private List<SatellitePart> Parts = new List<SatellitePart>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
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
        if ((Parts.Count) % 3 == 0 && Parts.Count > 0)
        {
            //If the all the parts in a level have been collected, start level complete animation
            //UIController.GetComponent<UIController>().startLevelComplete();
            if (SceneManager.GetActiveScene().name.Equals("IceWorld")) { startNextScene("Ice_Takeoff"); }
            else if (SceneManager.GetActiveScene().name.Equals("LavaWorld")) { startNextScene("Lava_Takeoff"); }
        }
    }

    public void startNextScene(string levelName) {
        Debug.Log("Onto the next one!");
        SceneManager.LoadScene(levelName);
    }

}
