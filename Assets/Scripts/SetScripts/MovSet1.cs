using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovSet1 : MonoBehaviour
{
    public GameObject rail1;
    public GameObject rail2;
    public GameObject rail3;
    public GameObject rail4;
    public int speed = 5;
    private int numRail;

    void Update()
    {
        if (gameObject.transform.position == rail1.transform.position)
        {
            numRail = 0;
        }
        else if (transform.position == rail2.transform.position)
        {
            numRail = 1;
        }
        else if (transform.position == rail3.transform.position)
        {
            numRail = 2;
        }
        else if (transform.position == rail4.transform.position)
        {
            numRail = 3;
        }
        switch(numRail)
        {
            case 0:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail2.transform.position, speed * Time.deltaTime);
                break;

            case 1:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail3.transform.position, speed * Time.deltaTime);
                break;

            case 2:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail4.transform.position, speed * Time.deltaTime);
                break;

            case 3:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail1.transform.position, speed * Time.deltaTime);
                break;
        }

    }
}

