﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MENU,
    NETTEST,
    GAMEPLAY,
    COPUNT
}

public class GameManager : MonoBehaviour {


#region singleton
    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
    }
#endregion

    public GameState CurrentGameState;

    public GameObject MainPanel = null;
    public GameObject NetTestPanel = null;

    public WWWManager wwwManager = null;


    private void InitGame()
    {
        CurrentGameState = GameState.MENU;
    }

    public void StartGame()
    {
        LoadDataFromServer();
    }

    private void LoadDataFromServer()
    {
        WWWManager.OnDataLoaded.AddListener(AfterDataLoaded);
        wwwManager.LoadDataFromServer();
    }

    private void AfterDataLoaded()
    {
        CurrentGameState = GameState.GAMEPLAY;
        PlayerMovment.OnPlayerKilled.AddListener(OnPlayerDeath);
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }

    public void GoToNetTest()
    {
        CurrentGameState = GameState.NETTEST;
        MainPanel.SetActive(false);
        NetTestPanel.SetActive(true);
    }

    public void GoBackToMainMenu()
    {
        CurrentGameState = GameState.MENU;
        MainPanel.SetActive(true);
        NetTestPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnPlayerDeath()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }


}
