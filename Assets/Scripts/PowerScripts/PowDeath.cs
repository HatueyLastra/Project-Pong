using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowDeath : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private int points;
    public float timeUntilDestruction = 10f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Invoke("Destruction", timeUntilDestruction);
            if (BallMovement.P1ball)
            {
                points = GameManagement.PointsP1;
                GameManagement.PointsP1 = points - 1;
                GameManagement.generatePower = true;
                Destroy(gameObject);
            }
            else if (BallMovement.P2ball)
            {
                points = GameManagement.PointsP2;
                GameManagement.PointsP2 = points - 1;
                GameManagement.generatePower = true;
                Destroy(gameObject);
            }
        }
    }
    void Destruction()
    {
        Destroy(gameObject);
    }
}
