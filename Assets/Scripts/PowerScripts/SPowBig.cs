using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPowBig : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
    public float time = 20f;
    private Vector3 sizeBig = new Vector3(0.5f, 6f, 1f);
    private Vector3 sizeNormal = new Vector3(0.5f, 2f, 1f);
    private Vector3 ballSizeBig = new Vector3(0.75f, 0.75f, 1f);
    private Vector3 BallSizeNormal = new Vector3(0.25f, 0.25f, 1f);
    private Vector3 OutOfMap = new Vector3(1000, 1000, 1000);
    GameObject player;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.gameObject;
        if (BallMovement.P1ball)
            player = player1;
        else if (BallMovement.P2ball)
            player = player2;
        if (player != null)
        {
            player.transform.localScale = sizeBig;
            ball.transform.localScale = ballSizeBig;
            transform.position = OutOfMap;
            Invoke("BackNormal", time);
        }
    }

    public void BackNormal()
    {
        player.transform.localScale = sizeNormal;
        ball.transform.localScale = BallSizeNormal;
        Destroy(gameObject);
    }
}
