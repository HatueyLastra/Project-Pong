using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowDeath : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private int points;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (BallMovement.P1ball)
        {
            points = GameManagement.PointsP1;
            GameManagement.PointsP1 = points - 1;
            Destroy(gameObject);
        }
        else if (BallMovement.P2ball)
        {
            points = GameManagement.PointsP2;
            GameManagement.PointsP2 = points - 1;
            Destroy(gameObject);
        }



    }
}
