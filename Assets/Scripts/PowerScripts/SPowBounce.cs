using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPowBounce : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    //public string tag = "Wall";
    bool activateBounce = false;
    public float time = 20f;
    private Vector3 OutOfMap;
    private bool turnMagenta = false;

    private void Start()
    {
            BallMovement.bounce = false;
        OutOfMap = transform.position;
    }
    private void Update()
    {
        if (activateBounce)
            BallMovement.bounce = true;
        if (turnMagenta)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Wall");

            foreach (GameObject obj in objectsWithTag)
            {
                Renderer objRenderer = obj.GetComponent<Renderer>();

                if (objRenderer != null)
                {
                    objRenderer.material.color = Color.magenta;
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            player1.transform.GetChild(0).gameObject.SetActive(true);
            player2.transform.GetChild(0).gameObject.SetActive(true);
            activateBounce = true;
                turnMagenta = true;
            
            

            transform.position = OutOfMap;
            Invoke("BackNormal", time);
        }
    }

    public void BackNormal()
    {
        player1.transform.GetChild(0).gameObject.SetActive(false);
        player2.transform.GetChild(0).gameObject.SetActive(false);
        activateBounce = false;
        BallMovement.bounce = false;
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject obj in objectsWithTag)
        {
            Renderer objRenderer = obj.GetComponent<Renderer>();

            if (objRenderer != null)
            {
                objRenderer.material.color = Color.white;
            }
        }
        GameManagement.generatePower = true;
        turnMagenta = false;
    }
}
