using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowBounce : MonoBehaviour
{
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
        if(activateBounce)
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
            activateBounce = true;
            turnMagenta = true;
            transform.position = OutOfMap;
            Invoke("BackNormal", time);
        }
    }

    public void BackNormal()
    {
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
