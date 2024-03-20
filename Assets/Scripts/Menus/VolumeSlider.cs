using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    [SerializeField] Slider slider; //reference to volume slider object

    // Start is called before the first frame update
    void Start()
    {
        //sets default volume based on two scenarios:
            //If: the game is first loaded
            //else: some settings are already set
        if (!PlayerPrefs.HasKey("musticVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
            Load();
        }
        else {
            Load();
        }
    }

    //updates volume when slider changes
    public void changeVolume() {
        AudioListener.volume = slider.value; 
        Save();
    }

    //Loads music settings based on previous scenes
    public void Load() {
        slider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    //Updates music settings based on current changes
    public void Save() {
        PlayerPrefs.SetFloat("musicVolume", slider.value);
    }

}
