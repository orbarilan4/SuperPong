using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public float resetDelay = 1;
    public int player1Score, player2Score;
    public int scoreTarget;
    public bool endGame = false, isShowingPause = false;
    public Transform player1, player2, ball;
    public TMP_Text score1, score2, winner;
    public KeyCode menuKeyCode, pauseKeyCode;
    public GameObject pauseScreen, winnerText, ballObject;
    private Vector3 ballPos, player1Pos, player2Pos, player1LocalScale, player2LocalScale;
    public BallMovement ballMovement;
    public ControlButton exitButton, pauseButton;

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
        if (Input.GetKeyDown(menuKeyCode) || exitButton.GetControlStatus() == "Exit Button")
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            exitButton.resetControlStatus();
        }

        if (Input.GetKeyDown(pauseKeyCode) || pauseButton.GetControlStatus() == "Pause Button")
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
            pauseButton.resetControlStatus();
        }
    }

    public void EndGame()
    {
        if (player1Score == scoreTarget)
        {
            Debug.Log("You Win !");
            setWinnerText(1);
            endGame = true;
        }
        if (player2Score == scoreTarget)
        {
            Debug.Log("You Lose !");
            setWinnerText(2);
            endGame = true;
        }
        if (endGame == true)
        {
            Pause(); // Pause game
            FindObjectOfType<AudioManager>().Play("GameOver");
            FindObjectOfType<AudioManager>().Stop("Intro");
        }
    }

    private void ResetBoard()
    {
        ballObject.SetActive(true);
        ballMovement.setBallVelocity();
        ballMovement.setOriginalSpeed(10);

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
        //Debug.Log("Player" + scorer + " scores!");

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
        if (player == 1)
        {
            winner.text = "You Win !";
        }
        else
        {
            winner.text = "You Lose !";
        }
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