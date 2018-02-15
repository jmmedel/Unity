using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public int whosTurn; // 0 = x and 1 = 0
    public int turnCount; // count the number of turn played
    public GameObject[] turnicon; // Display Whos turn it is
    public Sprite[] Playicon; // 0 = x icon and 1 = o icon
    public Button[] TictactoeSpace; // playable space for our game
    public int[] markedSpaces; // ID which space was marked by which player
    public Text winnerText; // Hold the text componet of the winner text;
    public GameObject[] winningLine; // hold all the different line for show that ther is a winner
    public GameObject winnerPanel;
    public int xPlayerScore;
    public int oPlayerScore;
    public Text xplayerScoreText;
    public Text oplayerScoreText;
    public Button xplayerButton;
    public Button oplayerButton;
    public GameObject CatImage;
    public AudioSource buttonClickAudio;


    // Use this for initialization
    void Start () {
        GameSetup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GameSetup()
    {
        whosTurn = 0;
        turnCount = 0;
        turnicon[0].SetActive(true);
        turnicon[1].SetActive(false);
        for(int i = 0; i< TictactoeSpace.Length; i++)
        {
            TictactoeSpace[i].interactable = true;
            TictactoeSpace[i].GetComponent<Image>().sprite = null;


        }
        for(int i = 0; i< markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
        }

    }

    public void TictactoeButton(int WhichNumber)
    {
        xplayerButton.interactable = false;
        oplayerButton.interactable = false;
        TictactoeSpace[WhichNumber].image.sprite = Playicon[whosTurn];
        TictactoeSpace[WhichNumber].interactable = false;
        markedSpaces[WhichNumber] = whosTurn+1;
        turnCount++;
        if(turnCount > 4)
        {
            bool isWinner = WinnerCheck();
            if(turnCount == 9  && isWinner == false)
            {
                Cat();
            }
            
        }

        if(whosTurn == 0)
        {
            whosTurn = 1;
            turnicon[0].SetActive(false);
            turnicon[1].SetActive(true);
        }
        else
        {
            whosTurn = 0;
            turnicon[0].SetActive(true);
            turnicon[1].SetActive(false);
        }
    }

    bool WinnerCheck()
    {   // check all the winning
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];
        var solution = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for(int i = 0; i<solution.Length; i++)
        {
            if(solution[i] == 3*(whosTurn+1))
            {
                WinnerDisplay(i);
                return true;
            }
        }

        return false;
    }

    void WinnerDisplay(int IndexIn)
    {   
        winnerPanel.gameObject.SetActive(true);
        if(whosTurn == 0)
        {
            xPlayerScore++;
            xplayerScoreText.text = xPlayerScore.ToString();
            winnerText.text = "Player x Winner!";
        }
        else if (whosTurn == 1)
        {
            oPlayerScore++;
            oplayerScoreText.text = oPlayerScore.ToString();
            winnerText.text = "Player 0 Winners";
        }
        winningLine[IndexIn].SetActive(true);
        
    }

    public void Rematch()
    {
        GameSetup();
        for(int i= 0; i<winningLine.Length; i++)
        {
            winningLine[i].SetActive(false);
        }
        winnerPanel.SetActive(false);
        xplayerButton.interactable = true;
        oplayerButton.interactable = true;
        CatImage.SetActive(false);
    }

    public void Restart()
    {
        Rematch();
        xPlayerScore = 0;
        oPlayerScore = 0;
        xplayerScoreText.text = "0";
        oplayerScoreText.text = "0";

    }

    public void SwitchPlayer(int whichplayer)
    {
        if(whichplayer == 0)
        {
            whosTurn = 0;
            turnicon[0].SetActive(true);
            turnicon[1].SetActive(false);
        }
        else if(whichplayer == 1)
        {
            whosTurn = 1;
            turnicon[0].SetActive(false);
            turnicon[1].SetActive(true);
        }
    }

    void Cat()
    {
        winnerPanel.SetActive(true);
        CatImage.SetActive(true);
        winnerText.text = "Cat";
    }

    public void Playbuttonclick()
    {
        buttonClickAudio.Play();
    }

}
