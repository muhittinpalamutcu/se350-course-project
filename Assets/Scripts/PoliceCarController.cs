using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarController : MonoBehaviour
{
    [HideInInspector]
    public Transform player1Car;
    public Rigidbody2D player1CarRigid;

    public float speed;
    public float stopDistance;
    private Vector2 velocity = Vector2.zero;
    private bool chase = false;
    private float player1CarVelocity;
    private bool gameOver;

    Rigidbody2D policeCarRigidBody2d;

    void Start()
    {
        player1Car = GameObject.FindGameObjectWithTag("Player1Car").transform;
        policeCarRigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Car != null && !gameOver)
        {
            if (Vector2.Distance(transform.position, player1Car.position) > stopDistance && player1CarVelocity > 5)
            {
                transform.position = Vector2.SmoothDamp(transform.position, player1Car.position, ref velocity, 0.5f, speed);
                transform.rotation = player1Car.rotation;
            }
            else
            {
                //stop moving case 
                if (player1CarVelocity < 5 || chase)
                {
                    transform.position = Vector2.SmoothDamp(transform.position, player1Car.position, ref velocity, 0.5f, speed);
                    transform.rotation = player1Car.rotation;
                }
            }
        }
    }

    public bool Chase
    {
        get { return chase; }
        set { chase = value; }
    }

    public float Player1CarVelocity
    {
        get { return player1CarVelocity; }
        set { player1CarVelocity = value; }
    }

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1Car")
        {
            Debug.Log("Player caught - game over");
            policeCarRigidBody2d.velocity = Vector2.zero;
            policeCarRigidBody2d.freezeRotation = true;
        }
    }

}
