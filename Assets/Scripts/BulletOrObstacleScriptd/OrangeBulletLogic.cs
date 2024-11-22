using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBulletLogic : MonoBehaviour
{
    public static bool P1ball;
    public static bool P2ball;
    public static bool bounce;
    public float speed;
    public float bounceSpeed = 0.5f;
    float directionx;
    float directiony;
    Vector2 moveInput;
    Rigidbody2D ballRB;
    private Vector3 BallSizeNormal = new Vector3(0.25f, 0.25f, 1f);
    public float ballTime = 8f;
    private float time;

    void Start()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Ball");
        transform.localScale = BallSizeNormal;
        P1ball = false;
        P2ball = false;
        speed = 5;
        ballRB = GetComponent<Rigidbody2D>();
        if (gameObject.transform.position == Vector3.zero)
        {
            directionx = GenerateRandom();
            directiony = GenerateRandom();
        }
        else
        {
            directiony = 0f;
            if (PowGun.hasGun == 1)
                directionx = 1f;
            else if (PowGun.hasGun == 2)
                directionx = -1;
        }
        moveInput = new Vector2(directionx, directiony).normalized;
        // Hace que las bolas no reboten entre si
        foreach (GameObject obj in objectsWithTag)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        time = ballTime;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time < 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        ballRB.MovePosition(ballRB.position + moveInput * speed * Time.fixedDeltaTime);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        moveInput = Vector2.Reflect(moveInput, normal);
        ballRB.velocity = moveInput * speed;
        if (collision.gameObject.CompareTag("Player1"))
        {
            speed = speed + 0.25f;
            P2ball = false;
            P1ball = true;
            time = ballTime;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            speed = speed + 0.25f;
            P1ball = false;
            P2ball = true;
            time = ballTime;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Goal1"))
        {
            GameManagement.PointsP2++;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Goal2"))
        {
            GameManagement.PointsP1++;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            time = ballTime; ;
        }

        if (collision.gameObject.CompareTag("Spring"))
        {
            speed = speed + bounceSpeed * 1.5f;
            time = ballTime; ;
        }

        if (bounce)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                speed = speed + bounceSpeed;
            }
        }
    }

    public float GenerateRandom()
    {
        float num = Random.Range(-1f, 1f);
        while (num < -0.80f || (num > -0.20f && num < 0.20f) || num > 0.80f)
        {
            num = Random.Range(-1f, 1f);
        }
        return num;
    }

}
