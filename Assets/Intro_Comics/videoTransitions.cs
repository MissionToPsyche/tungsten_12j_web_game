using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoTransitions : MonoBehaviour
{
    [SerializeField]
    public VideoPlayer video;

    [SerializeField]
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        video.Pause();
    }

}
