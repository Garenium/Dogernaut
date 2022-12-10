using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;
    private float yPosition;
    private Vector2 currentPosition;
    public Score scoreScript;
    private bool addedPoint = false;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;

        //Get a random speed from range 5.0 to 10.0 inclusive
        speed = Random.Range(5.0f, 8.0f);
        //Initialize the x coordinate while the sprite is moving relative to the speed of the sprite in delta time.
        currentPosition.x -= speed * Time.deltaTime;

        //Get a random y coordinate from -4.0 to 4.0 inclusive
        yPosition = Random.Range(-4.0f, 4.0f);
        currentPosition.y = yPosition;

        //reinitialize the coordinates
        transform.position = currentPosition;

        //Debugging purposes
        //Debug.Log("speed: " + speed + "\n yPosition: " + yPosition);

    }

    // Update is called once per frame
    void Update()
    {
        //Get the x position while the virus sprite is moving
        currentPosition = transform.position;
        currentPosition.x -= speed * Time.deltaTime;

        //If statement to check if the enemy passed the player's x coordinate
        if (currentPosition.x < -7 && addedPoint == false)
        {
            //Call the function IncreaseScore of the Score class to increment 
            //the score
            scoreScript.increaseScore();
            addedPoint = true;
        }

        //If the x position is less than -10.5 (out of the screen), reset it to 10.0f.
        //reset the enemy but with different coordinates and speed
        if (currentPosition.x < -10.5)
        {
            addedPoint = false;

            //currentPosition = transform.position;
            currentPosition.x = 10.0f;
            currentPosition.y = yPosition;

            speed = Random.Range(5.0f, 10.0f);
            yPosition = Random.Range(-4.0f, 4.0f);

            //Debugging purposes
            //Debug.Log("speed: " + speed + "\n yPosition: " + yPosition);
        }
        transform.position = currentPosition;
    }
}
