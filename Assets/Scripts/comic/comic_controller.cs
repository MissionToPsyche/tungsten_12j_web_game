using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class comic_controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]

    private VideoClip[] videoClips;
    [SerializeField]
    private VideoPlayer videoPlayer;

    private int videoClipsIndex = -1;

    public void nextVideo() {
        videoClipsIndex++;
        if (videoClipsIndex >= videoClips.Length)
        {
            SceneManager.LoadScene("Ice_Landing");
        }
        else {
            videoPlayer.clip = videoClips[videoClipsIndex];
            videoPlayer.Play();
        }
    }





    
}
