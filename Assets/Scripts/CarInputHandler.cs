using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    CarController carController;
    public PoliceCarController policeCarController;

    Rigidbody2D carRigidbody2D;

    private bool gameOver = false;

    void Awake()
    {
        carController = GetComponent<CarController>();
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Vector2 inputVector = Vector2.zero;
            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");

            carController.SetInputVector(inputVector);
            policeCarController.Player1CarVelocity = carRigidbody2D.velocity.magnitude;
        }
        else
        {
            carRigidbody2D.velocity = Vector2.zero;
            carRigidbody2D.freezeRotation = true;
            carController.SetInputVector(Vector2.zero);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            //Debug.Log("The player has collided with the wall!");
            policeCarController.Chase = true;
        }
        if (collision.gameObject.tag == "PoliceCar")
        {
            Debug.Log("Player caught - game over");
            gameOver = true;
            policeCarController.GameOver = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            //Debug.Log("The player no more collision with the wall!");
            policeCarController.Chase = false;
        }
    }
}
