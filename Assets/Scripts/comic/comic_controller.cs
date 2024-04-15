using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class comic_controller : MonoBehaviour
{
    // Start is called before the first frame update
    /*[SerializeField]
    private string[] videoClips;

    [SerializeField]
    private VideoPlayer videoPlayer;

    private int videoClipsIndex = -1;*/

    [SerializeField]
    private Sprite[] comicPages;

    [SerializeField]
    private Image pageDisplay;

    private int pageIndex = 0;
    
    public string nextScene;

    public void nextPage() {

        pageIndex++;
        if (pageIndex >= comicPages.Length)
        {
            SceneManager.LoadScene(nextScene);
            //Ice_Landing
            //MainMenu
        }
        else
        {
            pageDisplay.sprite = comicPages[pageIndex];
        }
    }

    /*public void nextVideo() {
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
    }*/
    
}
