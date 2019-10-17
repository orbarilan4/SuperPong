using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public float resetDelay = 1;
    public int player1Score, player2Score;
    public int scoreTarget;
    public bool endGame = false, isShowingInstructions = false, isShowingPause = false;
    public Transform player1, player2, ball;
    public TMP_Text score1, score2, winner, pressEsc;
    public KeyCode menuKeyCode, instructionsKeyCode, pauseKeyCode;
    public GameObject backgroundScreen, instructionsScreen, pauseScreen;
    public BallMovement ballMovement;

    void Start()
    {
        Resume();
        FindObjectOfType<AudioManager>().Play("Intro");
    }

    void Update()
    {
        if (Input.GetKeyDown(menuKeyCode))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
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
            Pause(); // Pause game
            FindObjectOfType<AudioManager>().Play("GameOver");
            FindObjectOfType<AudioManager>().Stop("Intro");
        }
    }

    private void ResetBoard()
    {
        ballMovement.speed = 10;
        ball.localScale = new Vector3(1, 1, 1);
        ball.position = new Vector3(0, 1, 0);
        player1.position = new Vector3(0, 1, 8.5f);
        player2.position = new Vector3(0, 1, -8.5f);
        player1.localScale = new Vector3(3f, 1f, 1f);
        player2.localScale = new Vector3(3f, 1f, 1f);
        FindObjectOfType<AudioManager>().Play("Applause");
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