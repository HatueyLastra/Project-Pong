using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPowShield : MonoBehaviour
{
    private Vector3 positionP1 = new Vector3(-9f, 4f, 0f);
    private Vector3 insideP1 = new Vector3(-0.5f, 0f, 0f);
    private Vector3 down = new Vector3(0f, -2f, 0f);
    private Vector3 positionP2 = new Vector3(9f, 4f, 0f);
    private Vector3 insideP2 = new Vector3(0.5f, 0f, 0f);
    private Vector3 OutOfMap;
    private Vector3 position;
    private Vector3 inside;
    private int goInside = 0;
    private GameObject shield;
    private SpriteRenderer shieldRender;
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        OutOfMap = transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            transform.position = OutOfMap;
            if (BallMovement.P1ball)
            {
                position = positionP1;
                inside = insideP1;
            }
            else if (BallMovement.P2ball)
            {
                position = positionP2;
                inside = insideP2;
            }
            if (position != Vector3.zero)
            {
                for (int i = 0; i < 5; i++)
                {
                    shield = Instantiate(prefab);
                    shield.transform.position = position + (down * i) + (inside * goInside);
                    if (i % 2 == 0)
                    {
                        shieldRender = shield.GetComponent<SpriteRenderer>();
                        shieldRender.material.color = Color.cyan;
                        goInside = 1;
                    }
                    else
                    {
                        shieldRender = shield.GetComponent<SpriteRenderer>();
                        shieldRender.material.color = Color.blue;
                        goInside = 0;
                    }
                }
                GameManagement.generatePower = true;
                Destroy(gameObject);
            }
        }


    }
}

