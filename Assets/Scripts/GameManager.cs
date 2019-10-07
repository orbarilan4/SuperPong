using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float resetDelay = 1;
    public int player1Score, player2Score;
    public int scoreTarget = 3;
    public Transform player1, player2, ball;
    public TMP_Text score1, score2;

    public void EndGame()
    {
        //show UI of winner/loser
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
        Debug.Log("Player" + scorer + " scores!");

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

        Invoke("ResetBoard", resetDelay);
    }

    private int AddScore(int playerScore)
    {
        int newScore = playerScore + 1;
        Debug.Log("Score: " + (newScore));
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
}
