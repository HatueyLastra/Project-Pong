using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowShield : MonoBehaviour
{
    private Vector3 positionP1 = new Vector3 (-9f,0f,0f);
    private Vector3 positionP2 = new Vector3(9f, 0f, 0f);
    private Vector3 position;
    [SerializeField] private GameObject prefab;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (BallMovement.P1ball)
        {
            position = positionP1;
        }
        else if (BallMovement.P2ball)
        {
            position = positionP2;
        }
        if (position != null)
        {
            GameObject shield = Instantiate(prefab);
            shield.transform.position = position;
            Destroy(gameObject);
        }


    }
}
