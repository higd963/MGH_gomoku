using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int whoTurn;
    public int turnCount;
    public GameObject[] turnIcons;
    public Sprite[] playIcons;
    public Button[] tictactoeSpaces;
    public int[] markedSpaces;
    public Text winnerText;
    public GameObject[] winningLine;
    public GameObject winnerPanel;
    public int xPlayersScore;
    public int oPlayersScore;
    public Text xPlayersScoreText;
    public Text oPlayersScoreText;
    public Button xPlayersButton;
    public Button oPlayersButton;
    int[,] mark;

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        whoTurn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for(int i=0; i<tictactoeSpaces.Length; i++)
        {
            tictactoeSpaces[i].interactable = true;
            tictactoeSpaces[i].GetComponent<Image>().sprite = null;

        }
        for(int i=0; i<markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TicTacToeButton(int WhichNumber)
    {
        xPlayersButton.interactable = true;
        oPlayersButton.interactable = true;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn+1;
        turnCount++;

        if(turnCount > 3)
        {
            WinnerCheck();
        }

        if(whoTurn==0)
        {
            whoTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            whoTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }

    }

    void WinnerCheck()
    {
        mark = new int[14, 14];
        int a = 0;
        
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                mark[i, j] = markedSpaces[a];
                a++;
            }
        }

        int countx = 0;
        int counto=0;
        for (int i = 0; i < 14; i++)
        {
            countx = 0;
            counto = 0;
            for (int j = 0; j < 14; j++)
            {
                if (mark[i, j] == 2)
                {
                    countx++;
                    counto = 0;
                }
                else if (mark[i, j] == 1)
                {
                    countx = 0;
                    counto++;
                }
                else
                {
                    countx = 0;
                    counto = 0;
                }


                if (countx == 5)
                {
                    WinnerDisplay(0);
                    return;
                }
                if (counto == 5)
                {
                    WinnerDisplay(1);
                    return;
                }
            }
        }

        for (int j = 0; j < 14; j++)
        {
            countx = 0;
            counto = 0;
            for (int i = 0; i < 14; i++)
            {
                if (mark[i, j] == 2)
                {
                    countx++;
                    counto = 0;
                }
                else if (mark[i, j] == 1)
                {
                    countx = 0;
                    counto++;
                }
                else
                {
                    countx = 0;
                    counto = 0;
                }


                if (countx == 5)
                {
                    WinnerDisplay(0);
                    return;
                }
                if (counto == 5)
                {
                    WinnerDisplay(1);
                    return;
                }
            }
        }


        for (int i = -1; i < 9; i++)
        {
            countx = 0;
            counto = 0;
            for (int j = -1; j < 9; j++)
            {
                int temp1 = i;
                int temp2 = j;
                for (int aa = 0; aa < 5; aa++)
                {
                    if (mark[temp1+1, temp2+1] == 2)
                    {
                        countx++;
                        counto = 0;
                    }
                    else if (mark[temp1+1, temp2+1] == 1)
                    {
                        countx = 0;
                        counto++;

                    }
                    else
                    {
                        countx = 0;
                        counto = 0;
                    }
                    temp1++;
                    temp2++;
                }
                if (countx == 5)
                {
                    WinnerDisplay(0);
                    return;
                }
                if (counto == 5)
                {
                    WinnerDisplay(1);
                    return;
                }
            }
        }

        for (int i = -1; i < 9; i++)
        {
            countx = 0;
            counto = 0;
            for (int j = 5; j < 15; j++)
            {
                int temp1 = i;
                int temp2 = j;
                for (int aa = 0; aa < 5; aa++)
                {
                    if (mark[temp1+1, temp2-1] == 2)
                    {
                        countx++;
                        counto = 0;
                    }
                    else if (mark[temp1+1, temp2-1] == 1)
                    {
                        countx = 0;
                        counto++;

                    }
                    else
                    {
                        countx = 0;
                        counto = 0;
                    }
                    temp1++;
                    temp2--;
                }
                if (countx == 5)
                {
                    WinnerDisplay(0);
                    return;
                }
                if (counto == 5)
                {
                    WinnerDisplay(1);
                    return;
                }
            }
        }
        return;
        
        /*
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];
        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for(int i=0; i<solutions.Length; i++)
        {
            if(solutions[i] == 3*(whoTurn+1))
            {
                WinnerDisplay(i);
                return;
            }
        }
         
         */

    }
    void WinnerDisplay(int indexIn)
    {
        winnerPanel.gameObject.SetActive(true);
        if(whoTurn==0)
        {
            xPlayersScore++;
            xPlayersScoreText.text = xPlayersScore.ToString();
            winnerText.text = "Player Black Wins!";
        }
        else if(whoTurn==1)
        {
            oPlayersScore++;
            oPlayersScoreText.text = oPlayersScore.ToString();
            winnerText.text = "Plyaer White Wins!";
        }
        for (int i = 0; i < tictactoeSpaces.Length; i++)
        {
            tictactoeSpaces[i].interactable = false;
            //tictactoeSpaces[i].GetComponent<Image>().sprite = null;

        }
        //winningLine[indexIn].SetActive(true);

    }
    public void Rematch()
    {
        GameSetup();
        for(int i=0; i<winningLine.Length; i++)
        {
            winningLine[i].SetActive(false);
        }
        winnerPanel.SetActive(false);
        xPlayersButton.interactable = true;
        oPlayersButton.interactable = true;
    }
    public void Restart()
    {
        Rematch();
        xPlayersScore = 0;
        oPlayersScore = 0;
        xPlayersScoreText.text = "0";
        oPlayersScoreText.text = "0";

    }

    public void SwitchPlayer(int whichPlayer)
    {
        if (whichPlayer == 0)
        {
            whoTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
        else if(whichPlayer==1)
        {
            
            whoTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
    }
}
