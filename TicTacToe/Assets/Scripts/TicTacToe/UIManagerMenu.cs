using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMenu : MonoBehaviour
{
    public int menuScene = 0, gameScene = 1;

    public virtual void StartGameButton()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void homeButton()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void singlePlayer(string state)
    {
        switch (state)
        {
            case "easy":
                PersistantManager.PM.currGameState = (PersistantManager.gameStates)1;
                break;
            case "medium":
                PersistantManager.PM.currGameState = (PersistantManager.gameStates)2;
                break;
            case "hard":
                PersistantManager.PM.currGameState = (PersistantManager.gameStates)3;
                break;
            case "multi":
                PersistantManager.PM.currGameState = (PersistantManager.gameStates)4;
                break;
        }
    }

    public void showLeaderboard(string board)
    {
        if (board == "singlePlayer")
        {
            //
        }
        else if (board == "multiPlayer")
        {
            //
        }       
    }
}
