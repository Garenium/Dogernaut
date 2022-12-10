
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Variables dealing with gravity
    public Rigidbody2D rigidbody2d;
    public float yForce;

    //Variables dealing with coordinates
    private Vector2 currentPosition;

    //Audio sources
    public AudioSource hitSound;
    public AudioSource jumpSound;

    //timer variable
    private float timeLeft = 1;

    //boolean variable to check collision
    bool isCollided;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Check if the condition of the collision is true.
        //If so, run the timer
        if (isCollided == true)
        {
                timeLeft -= Time.deltaTime;
                if(timeLeft < 0)
                    SceneManager.LoadScene("Main");
            
        }

        currentPosition = transform.position;

        //jump if user press space or right clicked
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //play jumpSound file
            jumpSound.Play();

            //Initialize forceToAdd with the user's desired amount of force in GUI
            Vector2 forceToAdd = new Vector2(0.0f, yForce);
            //Add the jump force to the sprite's gravity
            rigidbody2d.AddForce(forceToAdd);
  
            //Debug.Log("Jump!");
        }
        
        //If the player if out of range, reset the scene
        if(currentPosition.y > 5 || currentPosition.y < -7)
        {
            //Debug.Log("Out of range");
            SceneManager.LoadScene("Main");
        }

    }

    //Reload the scene if player collides with enemy
    public void OnCollisionEnter2D(Collision2D collision)
    {
        hitSound.Play();

        isCollided = true;
    }

    
}
