using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPowDizzy : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    Movement movement;
    private Vector3 OutOfMap = new Vector3(1000, 1000, 1000);
    GameObject player;
    public DizzyEffect dizzyEffect;
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
            dizzyEffect.startDizzy();
            transform.position = OutOfMap;
            StartCoroutine(Dizzyness());
        }
    }

    IEnumerator Dizzyness()
    {
        movement.Dizzy = 1;
        yield return new WaitForSeconds(4.0f);
        movement.Dizzy = 0;
        yield return new WaitForSeconds(3.0f);
        movement.Dizzy = 2;
        yield return new WaitForSeconds(3.0f);
        movement.Dizzy = 0;
        yield return new WaitForSeconds(2.0f);
        movement.Dizzy = 1;
        yield return new WaitForSeconds(5.0f);
        movement.Dizzy = 2;
        yield return new WaitForSeconds(6.0f);
        movement.Dizzy = 0;
        dizzyEffect.stopDizzy();
        Destroy(gameObject);

    }

}

