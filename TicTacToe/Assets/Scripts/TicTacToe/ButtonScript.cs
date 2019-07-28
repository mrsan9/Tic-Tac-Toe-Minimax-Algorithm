using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour
{
    public string placed;
    int x, y;
    
    private void Awake()
    {
        string[] pos;
        pos = gameObject.name.Split(',');
        x = System.Int32.Parse(pos[0]);
        y = System.Int32.Parse(pos[1]);
        GetComponent<Button>().onClick.AddListener(clicked);
    }
    public void clicked()
    {
        placed = PlayerManager.PM.turn;
        if (placed == "O")
            GetComponent<Image>().sprite = PlayerManager.PM.oImg;
        else
            GetComponent<Image>().sprite = PlayerManager.PM.xImg;

       
        PlayerManager.PM.grid[x, y] = placed;

        if (PlayerManager.PM.turn=="O")
            PlayerManager.PM.turn = "X";
        else
            PlayerManager.PM.turn = "O";
        
        PlayerManager.PM.count++;
        PlayerManager.PM.checkForWin();
        if (PlayerManager.PM.count < 9 && PlayerManager.PM.isWin == false)
        {
            switch (PersistantManager.PM.currGameState)
            {
                case PersistantManager.gameStates.easy:
                    PlayerManager.PM.computerTurnEasy();
                    break;
                case PersistantManager.gameStates.medium:
                    PlayerManager.PM.computerTurnMedium();
                    break;
            }
        }
        
        
    }
}
