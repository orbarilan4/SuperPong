using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody rb;
    public GameObject ball;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (rb.position.z > 0)
            {
                //the scorer is player2
                gameManager.Goal(2);
            }
            else
            {
                //the scorer is player1
                gameManager.Goal(1);
            }
            ball.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Goal");
        }
    }
}
