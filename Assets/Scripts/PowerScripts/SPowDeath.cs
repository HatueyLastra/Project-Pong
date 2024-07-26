using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPowDeath : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    GameObject player;
    private int points;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (BallMovement.P1ball)
        {
            player = player1;
            points = GameManagement.PointsP1;
            GameManagement.PointsP1 = points - 3;
            Destroy(gameObject);
        }
        else if (BallMovement.P2ball)
        {
            player = player2;
            points = GameManagement.PointsP2;
            GameManagement.PointsP2 = points - 3;
            Destroy(gameObject);
        }



    }
}
