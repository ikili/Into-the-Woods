﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author: JT Esmond
/// Date: 02/22/2021
/// <summary>
/// Pause Menu class that holds the functions for the pause menu, and also runs the pause menu functions
/// </summary>
public class PauseMenu : MonoBehaviour
{
    //static bool for the when the game is paused. Made it static in case it needs to be access in other scripts.
    public static bool GameIsPaused = false;
    public static bool BrewScreen = false;
    public static bool TutorialScreen = false;
    public static bool SettingsScreen = false;

    private void Start()
    {
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameIsPaused)
        {
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused  && !TurnOn.GameIsPaused && !BrewingEscape.GameIsPaused && !PopUpManager.GameIsPaused)
            {
                Resume();
            }
            else if( TurnOn.GameIsPaused || BrewingEscape.GameIsPaused || PopUpManager.GameIsPaused)
            {
                return;
            }
            else
            {
                Pause();
            }
        }

    }

    /// Author: JT Esmond
    /// Date: 02/22/2021
    /// <summary>
    /// function that unpauses the game
    /// </summary>
    public  void Resume()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    /// Author: JT Esmond
    /// Date: 02/22/2021
    /// <summary>
    /// function that pauses the game
    /// </summary>
    public void Pause()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
