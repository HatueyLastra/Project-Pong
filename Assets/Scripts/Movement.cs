using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D playerRB;
    private Vector2 moveInput;
    GameObject player;
    public float playerSpeed = 10f;
    public float rotationSpeed = 1.0f;
    public int Dizzy = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        player = this.gameObject;
    }

    void Update()
    {
        float movement = 0;
        if (Dizzy == 0)
        {
            if (player.tag == "Player1")
            {
                if (Input.GetKey(KeyCode.W))
                {
                    movement = 1;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    movement = -1;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(Vector3.forward * (-rotationSpeed * Time.deltaTime));
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    player.transform.rotation = Quaternion.Euler(Vector3.zero);
                }
            }

            if (player.tag == "Player2")
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    movement = 1;
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    movement = -1;
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Rotate(Vector3.forward * (-rotationSpeed * Time.deltaTime));
                }

                if (Input.GetKey(KeyCode.Return))
                {
                    player.transform.rotation = Quaternion.Euler(Vector3.zero);
                }
            }
        }
        else if (Dizzy == 1)
        {
            if (player.tag == "Player1")
            {
                if (Input.GetKey(KeyCode.S))
                {
                    movement = 1;
                }

                if (Input.GetKey(KeyCode.W))
                {
                    movement = -1;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(Vector3.forward * (-rotationSpeed * Time.deltaTime));
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    player.transform.rotation = Quaternion.Euler(Vector3.zero);
                }
            }

            if (player.tag == "Player2")
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    movement = 1;
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    movement = -1;
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Rotate(Vector3.forward * (-rotationSpeed * Time.deltaTime));
                }

                if (Input.GetKey(KeyCode.Return))
                {
                    player.transform.rotation = Quaternion.Euler(Vector3.zero);
                }
            }
        }

        else if (Dizzy == 2)
        {
            if (player.tag == "Player1")
            {
                if (Input.GetKey(KeyCode.A))
                {
                    movement = 1;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    movement = -1;
                }

                if (Input.GetKey(KeyCode.W))
                {
                    transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Rotate(Vector3.forward * (-rotationSpeed * Time.deltaTime));
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    player.transform.rotation = Quaternion.Euler(Vector3.zero);
                }
            }

            if (player.tag == "Player2")
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    movement = 1;
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    movement = -1;
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Rotate(Vector3.forward * (-rotationSpeed * Time.deltaTime));
                }

                if (Input.GetKey(KeyCode.Return))
                {
                    player.transform.rotation = Quaternion.Euler(Vector3.zero);
                }
            }
        }


        moveInput = new Vector2(0, movement);
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + moveInput * playerSpeed * Time.fixedDeltaTime);
    }
}
