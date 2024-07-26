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
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.position == rail1.transform.position)
            {
                while (gameObject.transform.position != rail2.transform.position)
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail2.transform.position, speed * Time.deltaTime);
            }
            else if (transform.position == rail2.transform.position)
            {
                while (gameObject.transform.position != rail3.transform.position)
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail3.transform.position, speed * Time.deltaTime);
            }
            else if (transform.position == rail3.transform.position)
            {
                while (gameObject.transform.position != rail4.transform.position)
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail4.transform.position, speed * Time.deltaTime);
            }
            else if (transform.position == rail4.transform.position)
            {
                while (gameObject.transform.position != rail1.transform.position)
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail1.transform.position, speed * Time.deltaTime);
            }
        
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rail2.transform.position, speed * Time.deltaTime);

    }
}
