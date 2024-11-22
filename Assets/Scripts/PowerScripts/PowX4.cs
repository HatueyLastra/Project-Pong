using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowX4 : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private Vector3 OutOfMap;
    private void Start()
    {
        OutOfMap = transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(prefab);
            Instantiate(prefab);
            Instantiate(prefab);
            transform.position = OutOfMap;
        }

    }
}
