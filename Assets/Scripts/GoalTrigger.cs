using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody ball;

    void OnTriggerEnter()
    {
        Debug.Log("OnTriggerEnter");
        if (ball.position.z > 0)
        {
            //the scorer is player2
            gameManager.Goal(2);
        }
        else
        {
            //the scorer is player1
            gameManager.Goal(1);
        }

    }
}
