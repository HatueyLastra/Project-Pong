using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SPowFast : MonoBehaviour
{
    private float timeAcc = 1f;
    public float minVel = 0.5f;
    public float maxVel = 2.5f;
    private Vector3 OutOfMap;

    private void Start()
    {
        OutOfMap = transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            transform.position = OutOfMap;
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        while(timeAcc > minVel)
        {
            yield return new WaitForSeconds(0.2f);
            timeAcc -= 0.03f;
            Time.timeScale = timeAcc;
        }
        yield return new WaitForSeconds(0.5f);
        while (timeAcc < maxVel)
        {
            yield return new WaitForSeconds(0.2f);
            timeAcc += 0.03f;
            Time.timeScale = timeAcc;
        }
        yield return new WaitForSeconds(5f);
        while (timeAcc > 1.5f)
        {
            yield return new WaitForSeconds(0.2f);
            timeAcc -= 0.05f;
            Time.timeScale = timeAcc;
        }
        GameManagement.generatePower = true;
    }
}
