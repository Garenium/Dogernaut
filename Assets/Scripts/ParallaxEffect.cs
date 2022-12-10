using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //get the coordinate of the background 
        Vector2 position = transform.position;
        //reinitialize the x coordinate relative to the speed at delta time.
        position.x -= speed * Time.deltaTime;

        //Reset the x coordinate to 81 if the background reaches -31
        if (position.x < -31f)
            position.x += 81f;

        //Reinitialize the coordinate
        transform.position = position;
    }
}
