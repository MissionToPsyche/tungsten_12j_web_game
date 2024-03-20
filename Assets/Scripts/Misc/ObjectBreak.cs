using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectBreak : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem asteroidParticles;

    [SerializeField]
    private Slider healthBar;

    private AudioSource audioSource;

    private ParticleSystem asteroidObj;


    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Asteroid":
                audioSource.Play();
                asteroidObj = Instantiate(asteroidParticles, other.transform.position, Quaternion.identity);
                other.gameObject.SetActive(false);

                //update Health
                healthBar.value -= 20;

                break;
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (asteroidObj != null)
        {
            if (!asteroidObj.isPlaying)
            {
                Destroy(asteroidObj.gameObject);
            }
        }
    }
}
