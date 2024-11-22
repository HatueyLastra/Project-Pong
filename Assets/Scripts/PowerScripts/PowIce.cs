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
    private Vector3 OutOfMap;
    GameObject player;
    Movement movement;
    public GameObject coldAnimationP1;
    public GameObject coldAnimationP2;
    private GameObject coldAnimation;

    private void Start()
    {
        OutOfMap = transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (BallMovement.P1ball)
            {
                player = player2;
                coldAnimation = coldAnimationP2;
            }
            else if (BallMovement.P2ball)
            {
                player = player1;
                coldAnimation = coldAnimationP1;
            }
            if (player != null)
            {
                movement = player.GetComponent<Movement>();
                movement.playerSpeed = iceSpeed;
                transform.position = OutOfMap;
                coldAnimation.SetActive(true);
                Invoke("BackNormal", time);
            }
        }
    }

    public void BackNormal()
    {
        coldAnimation.SetActive(false);
        movement.playerSpeed = normalSpeed;
        GameManagement.generatePower = true;
    }
}
