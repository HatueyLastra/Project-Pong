using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoRailMovement : MonoBehaviour
{
    public GameObject rail1;
    public GameObject rail2;
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
        switch (numRail)
        {
            case 0:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail2.transform.position, speed * Time.deltaTime);
                break;

            case 1:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail1.transform.position, speed * Time.deltaTime);
                break;
        }

    }
}
