using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSFX : MonoBehaviour
{

    [SerializeField]
    private AudioClip IceStepAudio;

    [SerializeField]
    private AudioClip LavaStepAudio;

    [SerializeField]
    private AudioClip JumpAudio;

    [SerializeField]
    private AudioSource PlayerAudio;

    //Update Step Sound based on level
    void Start(){

        updateStepAudio();

    }

    public void playStep() 
    {
        updateStepAudio();
        PlayerAudio.loop = true;
        PlayerAudio.Play();  
    }

    public void stopStep()
    {
        PlayerAudio.Stop();
    }

    public void playJump() {
        PlayerAudio.loop = false;
        PlayerAudio.clip = JumpAudio;
        PlayerAudio.Play();
    }

    private void updateStepAudio() {

        if (SceneManager.GetActiveScene().name.Equals("IceWorld"))
        {
            PlayerAudio.clip = IceStepAudio;
        }
        else
        {
            PlayerAudio.clip = LavaStepAudio;
        }

    }

}
