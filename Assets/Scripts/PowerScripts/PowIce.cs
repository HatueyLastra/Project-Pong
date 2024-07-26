using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowIce : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float iceSpeed = 2f;
    public float normalSpeed = 10f;
    public float time = 15f;
    private Vector3 OutOfMap = new Vector3(1000, 1000, 1000);
    GameObject player;
    Movement movement;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (BallMovement.P1ball)
            player = player2;
        else if (BallMovement.P2ball)
            player = player1;
        if (player != null)
        {
            movement = player.GetComponent<Movement>();
            movement.playerSpeed = iceSpeed;
            transform.position = OutOfMap;
            Invoke("BackNormal", time);
        }
    }

    public void BackNormal()
    {
        movement.playerSpeed = normalSpeed;
        Destroy(gameObject);
    }
}
