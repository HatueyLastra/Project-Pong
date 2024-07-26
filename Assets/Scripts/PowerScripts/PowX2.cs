using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowX2 : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(prefab);
        Destroy(gameObject);

    }

}
