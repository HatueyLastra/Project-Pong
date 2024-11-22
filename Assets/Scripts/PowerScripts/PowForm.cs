using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowForm : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject center;
    private GameObject formSelector;
    private GameObject form;
    private Vector3 formPosition;
    int previousForm;
    public float time = 5f;
    private Vector3 OutOfMap;
    GameObject player;
    GameObject truePlayer;

    void Start()
    {
        OutOfMap = transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (BallMovement.P1ball)
            {
                player = player1;
                truePlayer = player1;
                formSelector = center.transform.GetChild(2).gameObject;
            }
            else if (BallMovement.P2ball)
            {
                player = player2;
                truePlayer = player2;
                formSelector = center.transform.GetChild(4).gameObject;
            }
            if (player != null)
            {
                transform.position = OutOfMap;
                StartCoroutine(FormProcess());
            }
        }
    }

    void TransformRandomForm()
    {
        int num = Random.Range(0, 6);
        while (previousForm == num)
            num = Random.Range(0, 6);
        form = formSelector.transform.GetChild(num).gameObject;
        formPosition = form.transform.position;
        form.transform.position = player.transform.position;
        player.transform.position = formPosition;
        player = form;
        previousForm = num;
    }

    IEnumerator FormProcess()
    {
        TransformRandomForm();
        yield return new WaitForSeconds(time);
        TransformRandomForm();
        yield return new WaitForSeconds(time);
        TransformRandomForm();
        yield return new WaitForSeconds(time);
        truePlayer.transform.position = player.transform.position;
        player.transform.position = formPosition;
        GameManagement.generatePower = true;
    }
}
