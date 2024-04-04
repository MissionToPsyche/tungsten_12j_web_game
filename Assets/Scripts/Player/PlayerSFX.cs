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
    private AudioSource WalkingPlayer;

    [SerializeField]
    private AudioSource JumpingPlayer;


    Animator anim;

    private bool alreadyPlaying = false;

    //Update Step Sound based on level
    void Start(){

        updateStepAudio();
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetBool("Grounded") == false) 
        {
            stopStep();
            alreadyPlaying = false;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Move") && alreadyPlaying == false)
        {
            playStep();
            alreadyPlaying = true;
        }
    }

    public void playStep() 
    {

        //JumpingPlayer.gameObject.SetActive(false);
        WalkingPlayer.gameObject.SetActive(true);

        //updateStepAudio();
        WalkingPlayer.loop = true;
        WalkingPlayer.Play();  
    }

    public void stopStep()
    {
        WalkingPlayer.Stop();
        WalkingPlayer.gameObject.SetActive(false);
    }

    public void playJump() 
    {
        //stopStep();
        WalkingPlayer.loop = false;
        JumpingPlayer.gameObject.SetActive(true);

        //JumpingPlayer.loop = false;
        //JumpingPlayer.clip = JumpAudio;
        JumpingPlayer.Play();

    }

    private void updateStepAudio() {

        if (SceneManager.GetActiveScene().name.Equals("IceWorld"))
        {
            WalkingPlayer.clip = IceStepAudio;
        }
        else
        {
            WalkingPlayer.clip = LavaStepAudio;
        }

    }

}
