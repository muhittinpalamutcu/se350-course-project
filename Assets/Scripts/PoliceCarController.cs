using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarController : MonoBehaviour
{
    [HideInInspector]
    public Transform player1Car;
    //public Rigidbody2D player1CarRigid;

    [HideInInspector]
    public GameController gameController;

    public float speed;
    public float stopDistance;
    private Vector2 velocity = Vector2.zero;
    private bool chase = false;
    private float player1CarVelocity;
    private bool gameOver;

    Rigidbody2D policeCarRigidBody2d;

    private Queue<PointInSpace> pointsInSpace = new Queue<PointInSpace>();
    private float delay = 0.5f;

    void Start()
    {
        player1Car = GameObject.FindGameObjectWithTag("Player1Car").transform;
        policeCarRigidBody2d = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Car != null && !gameOver && !gameController.GameWin && gameController.StartGame)
        {
            if (Vector2.Distance(transform.position, player1Car.position) > stopDistance && player1CarVelocity > 5)
            {
                transform.position = Vector2.SmoothDamp(transform.position, player1Car.position, ref velocity, 0.5f, speed);
                //transform.rotation = player1Car.rotation;
            }
            else
            {
                //stop moving case 
                if (player1CarVelocity < 5 || chase)
                {
                    transform.position = Vector2.SmoothDamp(transform.position, player1Car.position, ref velocity, 0.5f, speed);
                    //transform.rotation = player1Car.rotation;
                }
            }
        }

        if (gameController.GameWin)
        {
            //Debug.Log("Player escaped");
            policeCarRigidBody2d.velocity = Vector2.zero;
            policeCarRigidBody2d.freezeRotation = true;
        }
    }

    //Instantiate(policecar, position and rotation);

    private void LateUpdate()
    {
        // Add the current target position to the list of positions
        pointsInSpace.Enqueue(new PointInSpace() { rotation = player1Car.rotation, Time = Time.time });

        // Move the camera to the position of the target X seconds ago 
        while (pointsInSpace.Count > 0 && pointsInSpace.Peek().Time <= Time.time - delay + Mathf.Epsilon)
        {
            // transform.position = Vector3.Lerp(transform.position, pointsInSpace.Dequeue().Position + offset, Time.deltaTime * speed);
            transform.rotation = pointsInSpace.Dequeue().rotation;
        }
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

    private struct PointInSpace
    {
        public float Time;
        public Quaternion rotation;
    }

}