using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPowDeath : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private int points;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Invoke("Destruction", 15f);
            if (BallMovement.P1ball)
            {
                points = GameManagement.PointsP1;
                GameManagement.PointsP1 = points - 3;
                GameManagement.generatePower = true;
                Destroy(gameObject);
            }
            else if (BallMovement.P2ball)
            {
                points = GameManagement.PointsP2;
                GameManagement.PointsP2 = points - 3;
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
