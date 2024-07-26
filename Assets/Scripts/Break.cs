using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player1") && !collision.gameObject.CompareTag("Player2"))
        Destroy(gameObject);
    }
}
