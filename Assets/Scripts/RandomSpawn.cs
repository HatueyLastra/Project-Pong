using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-5.5f,5.5f);
        float y = Random.Range(-3.5f,3.5f);
        Vector3 randomPosition = new Vector3(x,y,0);
        transform.position = randomPosition;
    }

}
