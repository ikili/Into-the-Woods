﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class contains the functions for changing the game mode from a main menu.
/// The variables set here are passed into Unity's PlayerPrefs and will be read later.
/// THIS THING NEEDS PROPER UI AND STUFF LIKE BUTTONS.
/// </summary>
public class ModeSelect_2 : MonoBehaviour
{
    // Variables to input before saving.
    public int enterRows;
    public int enterColumns;
    public bool enterUseSeed;
    public int enterSeed;

    public int playerDamageMultiplier;

    // Objects to toggle on/off for UI.
    public GameObject normalCheck;
    public GameObject bigCheck;
    public GameObject hardCheck;
    public GameObject bighardCheck;

    private void Awake()
    {
        CheckNormal();
    }

    #region Mode Modifier Buttons 

    public void CheckNormal()
    {
        enterRows = 4;
        enterColumns = 4;
        playerDamageMultiplier = 1;
        print("Setting Normal game: " + enterRows + "x" + enterColumns + " map, " + playerDamageMultiplier + "x Damage.");
        CommitPrefs();
        RefreshModeUI();
        normalCheck.SetActive(true);
    }

    public void CheckBig()
    {
        enterRows = 5;
        enterColumns = 5;
        playerDamageMultiplier = 1;
        print("Setting Big Map game: " + enterRows + "x" + enterColumns + " map, " + playerDamageMultiplier + "x Damage.");
        CommitPrefs();
        RefreshModeUI();
        bigCheck.SetActive(true);
    }

    public void CheckHard()
    {
        enterRows = 4;
        enterColumns = 4;
        playerDamageMultiplier = 2;
        print("Setting Hard Mode game: " + enterRows + "x" + enterColumns + " map, " + playerDamageMultiplier + "x Damage.");
        CommitPrefs();
        RefreshModeUI();
        hardCheck.SetActive(true);
    }

    public void CheckBigHard()
    {
        enterRows = 5;
        enterColumns = 5;
        playerDamageMultiplier = 2;
        print("Setting Big Map + Hard Mode game: " + enterRows + "x" + enterColumns + " map, " + playerDamageMultiplier + "x Damage.");
        CommitPrefs();
        RefreshModeUI();
        bighardCheck.SetActive(true);
    }

    public void ToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        print("Starting game with settings: " + enterRows + "x" + enterColumns + " map, " + playerDamageMultiplier + "x Damage.");
        SceneManager.LoadScene("MainGame");
    }

    #endregion

    #region ModeUIStuff

    private void CommitPrefs()
    {
        PlayerPrefs.SetInt(PrefTags.PWorldRows, enterRows);
        PlayerPrefs.SetInt(PrefTags.PWorldColumns, enterColumns);
        PlayerPrefs.SetInt(PrefTags.DmgMulti, playerDamageMultiplier);
    }

    private void RefreshModeUI()
    {
        normalCheck.SetActive(false);
        bigCheck.SetActive(false);
        hardCheck.SetActive(false);
        bighardCheck.SetActive(false);
    }

    #endregion

    #region Unused
    /// <summary>
    /// Sets the custom seed, if used.
    /// In order for this to work, this would need a function that calls it
    /// after typing into a fill-in field, or something like that.
    /// There's already code in the WorldGen that reads from PlayerPrefs if this
    /// is edited, so you'd just need to call this after editing enterUseSeed and enterSeed.
    /// </summary>
    void SaveSeed()
    {
        if (enterUseSeed)
        {
            PlayerPrefs.SetInt(PrefTags.UseSeed, 1);
            PlayerPrefs.SetInt(PrefTags.Seed, enterSeed);
            print("Seed set to " + enterSeed);
        }
        else
        {
            PlayerPrefs.SetInt(PrefTags.UseSeed, 0);
            print("Seed will be random.");
        }


    }
    #endregion
}