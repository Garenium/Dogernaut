using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] private GameObject pauseMenuUI;

    // Start is called before the first frame update
    void pauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0.0f;          //stop the time
            pauseMenuUI.SetActive(true);    //enable Pause GameObject
            AudioListener.volume = 0.0f;    //Silence
        }
        else if (!gameIsPaused)
        {
            //Opposite of above
            Time.timeScale = 1.0f;
            pauseMenuUI.SetActive(false);
            AudioListener.volume = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If user presses Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            //Check the bool is pause or not
            pauseGame();
        }
    }
}
