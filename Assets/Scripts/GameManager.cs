using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MENU,
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

    private void InitGame()
    {
        CurrentGameState = GameState.MENU;
    }

    public void StartGame()
    {
        CurrentGameState = GameState.GAMEPLAY;
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }


}
