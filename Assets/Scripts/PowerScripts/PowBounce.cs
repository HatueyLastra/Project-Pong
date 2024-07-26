using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowBounce : MonoBehaviour
{
    public string tag = "Wall";
    public GameObject ball;
    bool activateBounce = false;
    public float time = 20f;
    private Vector3 OutOfMap = new Vector3(1000, 1000, 1000);


    private void Update()
    {
        if(activateBounce)
        BallMovement.bounce = true;
        else
        BallMovement.bounce = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        activateBounce = true;
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objectsWithTag)
        {
            Renderer objRenderer = obj.GetComponent<Renderer>();

            if (objRenderer != null)
            {
                objRenderer.material.color = Color.magenta;
            }
        }

        transform.position = OutOfMap;
        Invoke("BackNormal", time);
    }

    public void BackNormal()
    {
        activateBounce = false;
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objectsWithTag)
        {
            Renderer objRenderer = obj.GetComponent<Renderer>();

            if (objRenderer != null)
            {
                objRenderer.material.color = Color.white;
            }
        }
        Invoke("Destruction", 1f);
    }

    public void Destruction()
    {
        Destroy(gameObject);
    }

}
