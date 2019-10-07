using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool goalTrigger = false;
    public float restartDelay = 1f;
    public int player1Score = 0, player2Score = 0;
    public int scoreTarget = 3;

    public void EndGame()
    {
        //show UI of winner/loser
    }

    public void ResetBoard()
    {
        //load current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetScore()
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
        goalTrigger = false;
        Invoke("Restart", restartDelay);

        if (scorer == 1)
        {
            AddScore(player1Score);
        }

        if (scorer == 2)
        {
            AddScore(player2Score);
        }

    }

    public void AddScore(int playerScore)
    {
        playerScore++;
    }
}
