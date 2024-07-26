using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPowFast : MonoBehaviour
{
    public float time = 15f;
    public float timeAcc = 2f;
    private Vector3 OutOfMap = new Vector3(1000, 1000, 1000);
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = timeAcc;
        transform.position = OutOfMap;
        Invoke("BackNormal", time * timeAcc);
    }

    public void BackNormal()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
