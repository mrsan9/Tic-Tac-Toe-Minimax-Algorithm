﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager PM;

    public string turn;//Current Player turn
    public bool isWin;//Check the win status
    public string winner; // to store winner string
    public int count;// move count for each placment
    public string[,] grid; //stores 3x3 array of the whole game element places
    public GameObject[] buttons; //all buttons os 3x3 tic tac toe grid

    public Sprite xImg, oImg;//Sprites for each button while placing

    string player, comp;//store value related to player 1 and 2.

    private void Awake()
    {
        if (PM == null)
            PM = this;
        isWin = false;
        grid = new string[3,3];
        
    }
    

    private void Start()
    {
        float rand = Random.value;
        if (rand >= 0.5f)
        {
            turn = "O";
            player = "O";
            comp = "X";
        }
        else
        {
            turn = "X";
            player = "X";
            comp = "O";
        }
        UIManagerGamePlay.UMG.setCurrTurnText();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            print("Medium Checking ");
            computerTurnMedium();
        }
           
    }


    //Check for win status of the game
    public void checkForWin()
    {
        if (!isWin)//Checking Horizontally
        {
            for (int i = 0; i < 3; ++i)
                if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2])
                {
                    winner = grid[i, 2];
                    if (!string.IsNullOrEmpty(winner))
                        isWin = true;
                    break;
                }
        }

        print(count);
        if (!isWin)//Checking Vertically
        {
             for (int i = 0; i < 3; ++i)
                if (grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i])
                {
                    winner = grid[2, i];
                    if (!string.IsNullOrEmpty(winner))
                        isWin = true;
                    break;
                }
        }


        if (!isWin)//Diagonal checking from left
        {
            if (grid[0, 0] == grid[1,1] && grid[1, 1] == grid[2, 2])
            {
                winner = grid[2,2];
                if (!string.IsNullOrEmpty(winner))
                    isWin = true;
                
            }            
        }
        if (!isWin)//Diagonal checking from right
        {
            if (grid[0, 2] == grid[1, 1] && grid[1, 1] ==  grid[2, 0] )
            {
                winner = grid[2,0];
                if (!string.IsNullOrEmpty(winner))
                    isWin = true;
                
            }         
        }

        if (isWin)
        {
            UIManagerGamePlay.UMG.winUIMang();      
        }
        if (count == 9 && isWin == false)
        {
            UIManagerGamePlay.UMG.drawUIMang();
        }
        UIManagerGamePlay.UMG.setCurrTurnText();     
                
    }

    public void computerTurnEasy()
    {
        List<string> pos = new List<string>();
        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
            {
                if (string.IsNullOrEmpty(grid[i, j]))
                {
                    string ePos = i + "," + j;
                    pos.Add(ePos);
                }
            }
        string[] randPos = pos[Random.Range(0, pos.Count)].Split(',');
        int i1 = System.Int32.Parse(randPos[0]);
        int j1 = System.Int32.Parse(randPos[1]);
        placeElement(i1,j1);
    }


    bool isMed;
    public void computerTurnMedium()
    {       

        if (count < 3)
            computerTurnEasy();
        else
        {
            isMed = false;
            if(isMed == false)
            medPlacement(comp);
            if(isMed == false)
            medPlacement(player);
            if (isMed == false)
            {
                computerTurnEasy();
                isMed = true;
            }
        }
    }

    void medPlacement(string t)
    {
        
        //Computer check for win placement horizontally
        if (isMed == false)
            for (int i = 0; i < 3; ++i)
            {
                if (grid[i, 0] == grid[i, 1] && grid[i, 0] == t && string.IsNullOrEmpty(grid[i, 2]))
                {
                    placeElement(i, 2); isMed = true; break;
                }
                if (grid[i, 0] == grid[i, 2] && grid[i, 2] == t && string.IsNullOrEmpty(grid[i, 1]))
                {
                    placeElement(i, 1); isMed = true; break;
                }
                if (grid[i, 1] == grid[i, 2] && grid[i, 1] == t && string.IsNullOrEmpty(grid[i, 0]))
                {
                    placeElement(i, 0); isMed = true; break;
                }
            }

        //Computer check for win placement vertically
        if (isMed == false)
            for (int i = 0; i < 3; ++i)
            {
                if (grid[0, i] == grid[1, i] && grid[0, i] == t && string.IsNullOrEmpty(grid[2, i]))
                {
                    placeElement(2, i); isMed = true; break;
                }
                if (grid[0, i] == grid[2, i] && grid[2, i] == t && string.IsNullOrEmpty(grid[1, i]))
                {
                    placeElement(1, i); isMed = true; break;
                }
                if (grid[1, i] == grid[2, i] && grid[1, i] == t && string.IsNullOrEmpty(grid[0, i]))
                {
                    placeElement(0, i); isMed = true; break;
                }
            }
        //Computer check for win placement diagonally
        if (isMed == false) {
            if (grid[0, 0] == grid[1, 1] && grid[0, 0] == t && string.IsNullOrEmpty(grid[2, 2]))
            {
                placeElement(2, 2); isMed = true;
            }
            if (grid[0, 0] == grid[2, 2] && grid[0, 0] == t && string.IsNullOrEmpty(grid[1, 1]))
            {
                placeElement(1, 1); isMed = true;
            }
            if (grid[1, 1] == grid[2, 2] && grid[1, 1] == t && string.IsNullOrEmpty(grid[0, 0]))
            {
                placeElement(0, 0); isMed = true;
            }
        }
        if (isMed == false)
        {
            if (grid[0, 2] == grid[1, 1] && grid[0, 2] == t && string.IsNullOrEmpty(grid[2, 0]))
            {
                placeElement(2, 0); isMed = true;
            }
            if (grid[0, 2] == grid[2, 0] && grid[0, 2] == t && string.IsNullOrEmpty(grid[1, 1]))
            {
                placeElement(1, 1); isMed = true;
            }
            if (grid[1, 1] == grid[2, 0] && grid[1, 1] == t && string.IsNullOrEmpty(grid[0, 2]))
            {
                placeElement(0, 2); isMed = true;
            }
        }



    }

    void placeElement(int x, int y)
    {
        int index = (x + y) + (x * 2);
        grid[x, y] = turn;
        if (turn == "O")
            buttons[index].GetComponent<Image>().sprite = oImg;
        else
            buttons[index].GetComponent<Image>().sprite = xImg;
        if (turn == "O")
            turn = "X";
        else
            turn = "O";
        ++count;
        checkForWin();
    }
  


}
