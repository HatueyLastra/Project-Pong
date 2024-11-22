using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPowGun : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject orangeBulllet;
    public GameObject skullBullet;
    public GameObject gunP1;
    public GameObject gunP2;
    public int ammo;
    public float time = 5f;
    public float vortexTime = 3f;
    public float vortexLong = 20f;
    private Vector3 OutOfMap;
    private Vector3 gunSightP1 = new Vector3(1f, 0f, 0f);
    private Vector3 gunSightP2 = new Vector3(-1f, 0f, 0f);
    private Vector3 gunP1Position = new Vector3(1000f, 0f, 0f);
    private Vector3 gunP2Position = new Vector3(-1000f, 0f, 0f);
    GameObject player;

    private void Start()
    {
        OutOfMap = transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (BallMovement.P1ball)
            {
                player = player1;
                PowGun.hasGun = 1;
            }
            else if (BallMovement.P2ball)
            {
                player = player2;
                PowGun.hasGun = 2;
            }
            if (player != null)
            {
                transform.position = OutOfMap;
                if (PowGun.hasGun == 1)
                    StartCoroutine(ShootingP1());
                else if (PowGun.hasGun == 2)
                    StartCoroutine(ShootingP2());
                StartCoroutine(Vortex());
            }
        }
    }

    public IEnumerator ShootingP1()
    {
        gunP1.transform.position = Vector3.zero;
        for (int i = 0; i < ammo / 2; i++)
        {
            yield return new WaitForSeconds(time);
            Instantiate(orangeBulllet, gunP1.transform.position + gunSightP1, Quaternion.identity);
            yield return new WaitForSeconds(time);
            Instantiate(skullBullet, gunP1.transform.position + gunSightP1, Quaternion.identity);
        }
        gunP1.transform.position = gunP1Position;
        GameManagement.generatePower = true;
        yield return new WaitForSeconds(10f);
        PowGun.hasGun = 0;
    }

    public IEnumerator ShootingP2()
    {
        gunP2.transform.position = Vector3.zero;
        for (int i = 0; i < ammo / 2; i++)
        {
            yield return new WaitForSeconds(time);
            Instantiate(orangeBulllet, gunP2.transform.position + gunSightP2, Quaternion.identity);
            yield return new WaitForSeconds(time);
            Instantiate(skullBullet, gunP2.transform.position + gunSightP2, Quaternion.identity);
        }
        gunP2.transform.position = gunP2Position;
        GameManagement.generatePower = true;
        yield return new WaitForSeconds(10f);
        PowGun.hasGun = 0;
    }

    public IEnumerator Vortex()
    {
        for (int i = 0; i < vortexLong; i++)
        {
            int num = Random.Range(0,2);
            if (num == 0)
                Instantiate(orangeBulllet, Vector3.zero, Quaternion.identity);
            else if (num == 1)
            Instantiate(skullBullet, Vector3.zero, Quaternion.identity);
            yield return new WaitForSeconds(vortexTime);
        }
    }
}
