using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : MonoBehaviour
{
    public GameObject ice;
    public float iceRecoil = 3;
    public GameObject iceSpawn;

    void CreateObject()
    {
        Instantiate(ice);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void OnEnable()
    {
        InvokeRepeating("CreateObject", 0f, iceRecoil);
    }
}
