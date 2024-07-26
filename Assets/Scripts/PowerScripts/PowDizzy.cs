using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowDizzy : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    Movement movement;
    private Vector3 OutOfMap = new Vector3(1000, 1000, 1000);
    GameObject player;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (BallMovement.P1ball)
        {
            player = player2;
            movement = player2.GetComponent<Movement>();
        }
        else if (BallMovement.P2ball)
        {
            player = player1;
            movement = player1.GetComponent<Movement>();
        }
        if (player != null)
        {
            transform.position = OutOfMap;
            StartCoroutine(Dizzyness());
        }
    }

     IEnumerator Dizzyness()
    {
        movement.Dizzy = 1;
        yield return new WaitForSeconds(5.0f);
        movement.Dizzy = 0;
        yield return new WaitForSeconds(3.0f);
        movement.Dizzy = 1;
        yield return new WaitForSeconds(7.0f);
        movement.Dizzy = 0;
        yield return new WaitForSeconds(2.0f);
        movement.Dizzy = 1;
        yield return new WaitForSeconds(5.0f);
        movement.Dizzy = 0;
        Destroy(gameObject);

    }
}
