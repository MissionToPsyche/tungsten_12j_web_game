using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpeed : MonoBehaviour
{
    float speed;
    float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5, 15);
        rotateSpeed = Random.Range(100, 500);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
            this.transform.Rotate(new Vector3(rotateSpeed * Time.deltaTime, 0f, 0f));
        }
    }
}
