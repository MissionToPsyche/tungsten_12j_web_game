using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Windows;
using System.Linq;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] asteroids;
    [SerializeField]
    private float spawnTimer = 2f;
    [SerializeField]
    private float rotateSpin = 3f;

    [SerializeField]
    private Transform ship;

    [SerializeField]
    private float distanceFromShip = 42f;

    private Camera cam;
    Vector3 point;

    private float x = 0f;
    private float y = 0f;
    private float z = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        foreach(var asteroid in asteroids)
        {
            asteroid.SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(AsteroidSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        point = cam.ScreenToWorldPoint(cam.transform.position);
    }


    private IEnumerator AsteroidSpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTimer);
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        var activeAsteroids = asteroids.Select(a => a.activeSelf).ToArray();
        int asteroidIndex = Random.Range(0, activeAsteroids.Length);
        int y = Random.Range(-16, 17);

        if (asteroids[asteroidIndex].activeSelf == false)
        {
            asteroids[asteroidIndex].SetActive(true);
            asteroids[asteroidIndex].transform.position = new Vector3(point.x - distanceFromShip, y, ship.position.z);
        }
    }
}
