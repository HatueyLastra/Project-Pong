using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowX4 : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(prefab);
        Instantiate(prefab);
        Instantiate(prefab);
        Destroy(gameObject);

    }
}
