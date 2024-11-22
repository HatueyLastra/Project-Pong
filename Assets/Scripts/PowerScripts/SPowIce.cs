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
    private Vector3 OutOfMap;
    GameObject player;
    Movement movement;
    public GameObject coldAnimationP1;
    public GameObject coldAnimationP2;
    private GameObject coldAnimation;
    public GameObject frozenSignP1;
    public GameObject frozenSignP2;
    private GameObject frozenSign;

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
                frozenSign = frozenSignP2;
            }
            else if (BallMovement.P2ball)
            {
                player = player1;
                coldAnimation = coldAnimationP1;
                frozenSign = frozenSignP1;
            }
            if (player != null)
            {
                movement = player.GetComponent<Movement>();
                movement.playerSpeed = freeze;
                for (int i = 0; i < 10; i++)
                    Instantiate(iceCube);
                transform.position = OutOfMap;
                coldAnimation.SetActive(true);
                frozenSign.SetActive(true);
                Invoke("BackIce", freezeTime);
            }
        }
    }

    public void BackIce()
    {
        frozenSign.SetActive(false);
        movement.playerSpeed = iceSpeed;
        Invoke("BackNormal", time);
    }

    public void BackNormal()
    {
        coldAnimation.SetActive(false);
        movement.playerSpeed = normalSpeed;
        GameManagement.generatePower = true;
    }
}
