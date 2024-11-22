using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    private Vector2 moveInput;
    public GameObject player;
    public float gunSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movement = 0;
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
            }
        

        moveInput = new Vector2(0, movement);
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + moveInput * gunSpeed * Time.fixedDeltaTime);
    }
}
