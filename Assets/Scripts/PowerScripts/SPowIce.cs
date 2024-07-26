using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPowIce : MonoBehaviour
{
    [SerializeField] private GameObject iceCube;
    public GameObject player1;
    public GameObject player2;
    private float freeze = 0f;
    public float iceSpeed = 2f;
    public float normalSpeed = 10f;
    public float time = 15f;
    public float freezeTime = 5f;
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
            movement.playerSpeed = freeze;
            for (int i = 0; i < 15; i++)
                Instantiate(iceCube);
            transform.position = OutOfMap;
            Invoke("BackIce", freezeTime);
        }
    }

    public void BackIce()
    {
        movement.playerSpeed = iceSpeed;
        Invoke("BackNormal", time);
    }

    public void BackNormal()
    {
        movement.playerSpeed = normalSpeed;
        Destroy(gameObject);
    }
}
