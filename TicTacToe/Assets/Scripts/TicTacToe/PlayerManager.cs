using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager PM;

    public string turn;
    public Text playerTurn;
    public bool isWin,isDraw;
    public string winner;
    public GameObject[,] objs;
    public int count;
    public string[,] grid;
    public GameObject[] buttons;

    public Sprite xImg, oImg;

    [Header("winner UI")]
    public GameObject winnerUi;
    public Text winText;


    private void Awake()
    {
        if (PM == null)
            PM = this;
        isWin = false;
        grid = new string[3,3];        
    }
    string player, comp;
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
       
    }

    private void Update()
    {
        if (turn == "O")
            playerTurn.text = "Player turn: " + "O";
        else
            playerTurn.text = "Player turn: " + "X";

        if (Input.GetMouseButtonDown(1))
            checkForWin();
    }

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
            winnerUi.SetActive(true);
            winText.text = "Winner is " + winner;
        }
        if (count == 9 && isWin == false)
        {
            winnerUi.SetActive(true);
            winText.text = "Tied! Play Again.";
        }
               
                
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
    void placeElement(int x,int y)
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

    public void computerTurnMedium()
    {
        //Computer check for win placement horizontally
        string[] elements = new string[3];
        for (int i = 0; i < 3; ++i)
        {
            
            if (grid[i, 0] == grid[i, 1] && !string.IsNullOrEmpty(grid[i,0]) && string.IsNullOrEmpty(grid[i, 2]))
            {
                elements[0] = grid[i, 0];
            }
            if (grid[i, 0] == grid[i, 2] && !string.IsNullOrEmpty(grid[i, 0]) && string.IsNullOrEmpty(grid[i, 1]))
            {
                elements[1] = grid[i, 2];
            }
            if (grid[i, 1] == grid[i, 2] && !string.IsNullOrEmpty(grid[i, 1]) && string.IsNullOrEmpty(grid[i, 0]))
            {
                elements[2] = grid[i, 1];
            }
           
        }

        for (int j = 0; j < 3; ++j)
        {
            if (elements[j] == comp)
            {
                switch (j)
                {
                    case 0:
                        placeElement(j, 2);
                        break;
                    case 1:
                        placeElement(j, 1);
                        break;
                    case 2:
                        placeElement(j, 0);
                        break;
                }               
            }
            if (elements[j] == player)//if not breaking 
            {
                switch (j)
                {
                    case 0:
                        placeElement(j, 2);
                        break;
                    case 1:
                        placeElement(j, 1);
                        break;
                    case 2:
                        placeElement(j, 0);
                        break;
                }
            }

        }
        //Computer check for win placement vertically


    }
    public void restartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }



}
