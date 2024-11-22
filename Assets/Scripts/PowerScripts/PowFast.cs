using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowFast : MonoBehaviour
{
    public float time = 15f;
    public float timeAcc = 2f;
    private Vector3 OutOfMap;

    private void Start()
    {
        OutOfMap = transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Time.timeScale = timeAcc;
            transform.position = OutOfMap;
            Invoke("BackNormal", time * timeAcc);
        }
     }

     public void BackNormal()
     {
         Time.timeScale = 1;
        GameManagement.generatePower = true;
    }
    
}
