using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public float resetDelay = 1;
    public int player1Score, player2Score;
    public int scoreTarget;
    public bool endGame = false;
    public Transform player1, player2, ball;
    public TMP_Text score1, score2, winner, pressEsc;

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
            Time.timeScale = 0; // Pause game
        }
    }
    private void ResetBoard()
    {
        ball.position = new Vector3(0, 1, 0);
        player1.position = new Vector3(0, 1, 8.5f);
        player2.position = new Vector3(0, 1, -8.5f);

        //todo: reset ball movement, for now it moves the same direction as before
    }

    private void ResetScore()
    {
        ResetBoard();
        player1Score = 0;
        player2Score = 0;
    }

    public void Goal(int scorer)
    {
        Debug.Log("Player" + scorer + " score!");

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
        winner.text = "Player " + player + " Wins !";
        pressEsc.text = "Press the Esc key for startup Menu";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}