using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerGamePlay : UIManagerMenu
{
    public GameObject winnerUI;
    public Text winText,currTurnText;
    public static UIManagerGamePlay UMG;

    private void Awake()
    {
        if (UMG == null)
            UMG = this;
    }
    private void OnGUI()
    {
        //
    }
    public void setCurrTurnText()
    {
        currTurnText.text = "Player Turn: " + PlayerManager.PM.turn;
    }
    public void winUIMang()
    {
        winnerUI.SetActive(true);
        winText.text = "Winner is " +PlayerManager.PM.winner;
    }
    public void drawUIMang()
    {
        winnerUI.SetActive(true);
        winText.text = "Tied! Play Again.";
    }
}
