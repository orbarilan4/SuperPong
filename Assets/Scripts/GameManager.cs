using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1;
    public int player1Score, player2Score;
    public int scoreTarget = 3;

    public Transform player1, player2, ball;

    public void EndGame()
    {
        //show UI of winner/loser
    }

    private void ResetBoard()
    {
        //reset positions
        ball.position = new Vector3(0, 1, 0);
        player1.position = new Vector3(0, 1, 8.5f);
        player2.position = new Vector3(0, 1, -8.5f);

        //todo: reset ball movement, for now it moves the same direction as before
    }

    private void ResetScore()
    {
        //load current scene
        ResetBoard();
        //reset score
        player1Score = 0;
        player2Score = 0;
    }

    public void Goal(int scorer)
    {
        //todo: show goal animation
        //todo: change score

        Debug.Log("Goal!");

        if (scorer == 1)
        {
            player1Score = AddScore(player1Score);
        }

        if (scorer == 2)
        {
            player2Score = AddScore(player2Score);
        }

        Debug.Log("Player" + scorer + " scores!");

        Invoke("ResetBoard", restartDelay);
    }

    private int AddScore(int playerScore)
    {
        Debug.Log("Score: " + (playerScore + 1));
        return playerScore + 1;
    }
}
