using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowSmall : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float time = 10f;
    private Vector3 sizeSmall = new Vector3(0.5f, 1f, 1f);
    private Vector3 sizeNormal = new Vector3(0.5f, 2f, 1f);
    private Vector3 OutOfMap;
    GameObject player;

    private void Start()
    {
        OutOfMap = transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (BallMovement.P1ball)
                player = player1;
            else if (BallMovement.P2ball)
                player = player2;
            if (player != null)
            {
                player.transform.localScale = sizeSmall;
                transform.position = OutOfMap;
                Invoke("BackNormal", time);
            }
        }
    }

    public void BackNormal()
    {
        player.transform.localScale = sizeNormal;
        GameManagement.generatePower = true;
    }
}
