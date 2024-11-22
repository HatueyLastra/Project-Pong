using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPowDizzy : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    Movement movement;
    private Vector3 OutOfMap;
    GameObject player;
    public DizzyEffect dizzyEffect;
    public GameObject dizzySignP1;
    public GameObject dizzySignP2;
    public GameObject superDizzySignP1;
    public GameObject superDizzySignP2;
    private GameObject dizzySign;
    private GameObject superDizzySign;

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
                superDizzySign = superDizzySignP2;
                movement = player2.GetComponent<Movement>();
            }
            else if (BallMovement.P2ball)
            {
                player = player1;
                dizzySign = dizzySignP1;
                superDizzySign = superDizzySignP1;
                movement = player1.GetComponent<Movement>();
            }
            if (player != null)
            {
                dizzyEffect.startDizzy();
                transform.position = OutOfMap;
                StartCoroutine(Dizzyness());
            }
        }
    }

    IEnumerator Dizzyness()
    {
        movement.Dizzy = 1;
        dizzySign.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        movement.Dizzy = 0;
        dizzySign.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        movement.Dizzy = 2;
        dizzySign.SetActive(true);
        superDizzySign.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        movement.Dizzy = 0;
        dizzySign.SetActive(false);
        superDizzySign.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        movement.Dizzy = 1;
        dizzySign.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        movement.Dizzy = 2;
        superDizzySign.SetActive(true);
        yield return new WaitForSeconds(6.0f);
        movement.Dizzy = 0;
        dizzySign.SetActive(false);
        superDizzySign.SetActive(false);
        dizzyEffect.stopDizzy();
        GameManagement.generatePower = true;
    }

}

