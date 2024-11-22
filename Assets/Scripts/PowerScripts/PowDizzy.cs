using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowDizzy : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    Movement movement;
    private Vector3 OutOfMap;
    GameObject player;
    public GameObject dizzySignP1;
    public GameObject dizzySignP2;
    private GameObject dizzySign;
    public GameObject dizzyWarningP1;
    public GameObject dizzyWarningP2;
    private GameObject dizzyWarning;

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
                dizzySign = dizzySignP2;
                dizzyWarning = dizzyWarningP2;
                movement = player2.GetComponent<Movement>();
            }
            else if (BallMovement.P2ball)
            {
                player = player1;
                dizzySign = dizzySignP1;
                dizzyWarning = dizzyWarningP1;
                movement = player1.GetComponent<Movement>();
            }
            if (player != null)
            {
                transform.position = OutOfMap;
                StartCoroutine(Dizzyness());
            }
        }
    }

     IEnumerator Dizzyness()
    {
        movement.Dizzy = 1;
        dizzySign.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        movement.Dizzy = 0;
        dizzySign.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        movement.Dizzy = 1;
        dizzySign.SetActive(true);
        yield return new WaitForSeconds(7.0f);
        movement.Dizzy = 0;
        dizzySign.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        movement.Dizzy = 1;
        dizzySign.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        movement.Dizzy = 0;
        dizzySign.SetActive(false);
        GameManagement.generatePower = true;
    }
}
