using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;

    private float xInput;
    private float yInput; 

    private Transform ship;

    private float minY = -18f;
    private float maxY = 18f;
    private float minX = -30f;
    private float maxX = 30f;

    private void Awake()
    {
        Cursor.visible = false;
        ship = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Boundaries();

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        ship.Translate(new Vector2(xInput * speed * Time.deltaTime, yInput * speed * Time.deltaTime));
    }

    private void Boundaries()
    {
        if(ship.position.y < minY)
        {
            ship.position = new Vector2(ship.position.x, minY);
        }
        else if(ship.position.y > maxY)
        {
            ship.position = new Vector2(ship.position.x, maxY);
        }
        if (ship.position.x < minX)
        {
            ship.position = new Vector2(minX, ship.position.y);
        }
        else if(ship.position.x > maxX)
        {
            ship.position = new Vector2(maxX, ship.position.y);
        }
    }
}
