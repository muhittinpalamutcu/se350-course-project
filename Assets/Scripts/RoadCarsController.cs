using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCarsController : MonoBehaviour
{
    [HideInInspector]
    public GameController gameController;

    float moveSpeed = 4f;
    public Vector3 currentposition;
    public Vector3 startPositionGameController1;
    public Vector3 endPositionGameController1;
    public Vector3 startPositionGameController2;
    public Vector3 endPositionGameController2;
    public Vector3 startPositionGameController3;
    public Vector3 endPositionGameController3;
    public Vector3 startPositionGameController4;
    public Vector3 endPositionGameController4;
    Rigidbody2D car;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody2D>();
        currentposition = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        startPositionGameController1 = gameController.roadCar1StartPoint.position;
        endPositionGameController1 = gameController.roadCar1EndPoint.position;
        startPositionGameController2 = gameController.roadCar2StartPoint.position;
        endPositionGameController2 = gameController.roadCar2EndPoint.position;
        startPositionGameController3 = gameController.roadCar3StartPoint.position;
        endPositionGameController3 = gameController.roadCar3EndPoint.position;
        startPositionGameController4 = gameController.roadCar4StartPoint.position;
        endPositionGameController4 = gameController.roadCar4EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.GameOver && !gameController.GameWin)
        {
            if (startPositionGameController1 == currentposition)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, endPositionGameController1, step);
            }
            else if (startPositionGameController2 == currentposition)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, endPositionGameController2, step);
            }
            else if (startPositionGameController3 == currentposition)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, endPositionGameController3, step);
            }
            else if (startPositionGameController4 == currentposition)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, endPositionGameController4, step);
            }
        }
        else
        {
            car.velocity = Vector2.zero;
            car.freezeRotation = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);

        }
    }

}
