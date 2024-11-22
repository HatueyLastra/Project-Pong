using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeGenerator : MonoBehaviour
{
    public GameObject rail1;
    public Vector3 rail1Position;
    public GameObject rail4;
    public Vector3 rail4Position;
    public GameObject iceRight;
    public GameObject iceLeft;
    public float iceRecoil = 3;


    void CrearObjeto()
    {
        Instantiate(iceRight, rail1Position, Quaternion.identity);
        Instantiate(iceLeft, rail4Position, Quaternion.identity);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void OnEnable()
    {
        InvokeRepeating("CrearObjeto", 0f, iceRecoil);
    }
}
