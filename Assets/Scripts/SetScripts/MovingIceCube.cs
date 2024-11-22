using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MovingIceCube : MonoBehaviour
{
    public GameObject rail1;
    public GameObject rail2;
    public float speed = 5;
    private int numRail = -1;
    private int numDestroy = 0;

    void Update()
    {
        if (gameObject.transform.position == rail1.transform.position)
        {
            numRail = 0;
            numDestroy++;
            if(numDestroy == 2)
            {
                Destroy(gameObject);
            }
        }
        else if (transform.position == rail2.transform.position)
{
    numRail = 1;
            numDestroy++;
            if (numDestroy == 2)
            {
                Destroy(gameObject);
            }
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
