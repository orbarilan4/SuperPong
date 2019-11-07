﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;

public class ARGameManager : MonoBehaviour
{
    private float resetDelay = 1;
    private int player1Score, player2Score;
    public int scoreTarget;
    private bool endGame = false, isShowingInstructions = false, isShowingPause = false;
    public Transform player1, player2, ball;
    public TMP_Text score1, score2, winner, pressEsc;
    public KeyCode menuKeyCode, instructionsKeyCode, pauseKeyCode;
    public GameObject backgroundScreen, instructionsScreen, pauseScreen, winnerText, pressEscText, ballObject;
    private Vector3 ballPos, player1Pos, player2Pos, player1LocalScale, player2LocalScale;
    public ARBallMovement ballMovement;
    public ARPlayerMovement playerMovement;

    void Start()
    {
        OnLevelWasLoaded();
    }

    void OnLevelWasLoaded()
    {
        Debug.Log("New Game");
        Resume();
        SavePositions();
        FindObjectOfType<AudioManager>().Play("Intro");
    }

    private void SavePositions()
    {
        ballPos = ball.position;
        player1Pos = player1.position;
        player2Pos = player2.position;
        player1LocalScale = player1.localScale;
        player2LocalScale = player2.localScale;
    }

    void Update()
    {
        score1.text = ball.transform.position.x.ToString("F3");
        score2.text = ballMovement.collided.ToString();

        // score1.text = "1 - (" + player1.position.x.ToString("F2") + "," + player1.position.y.ToString("F2") + "," + player1.position.z.ToString("F2") + ")"
        // + "(" + wall1.position.x.ToString("F2") + "," + wall1.position.y.ToString("F2") + "," + wall1.position.z.ToString("F2") + ")";
        // score2.text = "2 - (" + player2.position.x.ToString("F2") + "," + player2.position.y.ToString("F2") + "," + player2.position.z.ToString("F2") + ")"
        // + "(" + wall2.position.x.ToString("F2") + "," + wall2.position.y.ToString("F2") + "," + wall2.position.z.ToString("F2") + ")";

        //menu key
        if (Input.GetKeyDown(menuKeyCode))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

        //instructions key
        if (Input.GetKeyDown(instructionsKeyCode))
        {
            isShowingInstructions = !isShowingInstructions;
            backgroundScreen.SetActive(isShowingInstructions);
            instructionsScreen.SetActive(isShowingInstructions);
            if (isShowingInstructions)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

        //pause key
        if (Input.GetKeyDown(pauseKeyCode))
        {
            isShowingPause = !isShowingPause;
            pauseScreen.SetActive(isShowingPause);
            if (isShowingPause)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void EndGame()
    {
        if (player1Score == scoreTarget)
        {
            Debug.Log("player 1 wins !");
            setWinnerText(1);
            endGame = true;
        }
        if (player2Score == scoreTarget)
        {
            Debug.Log("player 2 wins !");
            setWinnerText(2);
            endGame = true;
        }
        if (endGame == true)
        {
            Pause();
            FindObjectOfType<AudioManager>().Play("GameOver");
            FindObjectOfType<AudioManager>().Stop("Intro");
        }
    }

    private void ResetBoard()
    {
        ballObject.SetActive(true);
        ballMovement.setBallVelocity();
        ballMovement.setOriginalSpeed(0.4f);

        ball.position = ballPos;
        player1.position = player1Pos;
        player2.position = player2Pos;
        player1.localScale = player1LocalScale;
        player2.localScale = player2LocalScale;
        FindObjectOfType<AudioManager>().Play("Applause");
    }

    private void ResetScore()
    {
        ResetBoard();
        player1Score = 0;
        player2Score = 0;
    }

    public void Goal(int scorer)
    {
        if (scorer == 1)
        {
            player1Score = AddScore(player1Score);
            setScoreText(scorer, player1Score);
        }
        else
        {
            player2Score = AddScore(player2Score);
            setScoreText(scorer, player2Score);
        }
        EndGame();
        Invoke("ResetBoard", resetDelay);
    }

    private int AddScore(int playerScore)
    {
        int newScore = playerScore + 1;
        return newScore;
    }

    private void setScoreText(int player, int score)
    {
        if (player == 1)
        {
            score1.text = "Score: " + score.ToString();
        }
        else
        {
            score2.text = "Score: " + score.ToString();
        }
    }
    private void setWinnerText(int player)
    {
        winnerText.SetActive(true);
        pressEscText.SetActive(true);
        winner.text = "Player " + player + " Wins !";
        pressEsc.text = "Press the Esc key for startup Menu";
    }

    void Pause()
    {
        Time.timeScale = 0f;
    }

    void Resume()
    {
        Time.timeScale = 1f;
    }
}