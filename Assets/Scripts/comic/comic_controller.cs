using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class comic_controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string[] videoClips;

    [SerializeField]
    private VideoPlayer videoPlayer;

    public string nextScene;

    private int videoClipsIndex = -1;

    public void nextVideo() {
        videoClipsIndex++;
        if (videoClipsIndex >= videoClips.Length)
        {
            SceneManager.LoadScene(nextScene);
            //Ice_Landing
            //MainMenu
        }
        else {
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoClips[videoClipsIndex]);
            videoPlayer.Play();
        }
    }





    
}
