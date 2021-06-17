using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform player1CarStartPoint;
    public Transform policeCarStartPoint;
    public Transform roadCar1StartPoint;
    public Transform roadCar1EndPoint;
    public Transform roadCar2StartPoint;
    public Transform roadCar2EndPoint;
    public Transform roadCar3StartPoint;
    public Transform roadCar3EndPoint;
    public Transform roadCar4StartPoint;
    public Transform roadCar4EndPoint;

    public List<GameObject> cars = new List<GameObject>();

    float spawnTimer = 2f;
    float timer = 0f;
    private bool gameOver = false;
    private bool gameWin = false;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cars[0], player1CarStartPoint.position, transform.rotation * Quaternion.Euler(0f, 0f, 270f));
        Instantiate(cars[1], policeCarStartPoint.position, transform.rotation * Quaternion.Euler(0f, 0f, 270f));
        Instantiate(cars[Random.Range(2, cars.Count)], roadCar1StartPoint.position, transform.rotation * Quaternion.Euler(0f, 0f, 180f));
        Instantiate(cars[Random.Range(2, cars.Count)], roadCar2StartPoint.position, Quaternion.identity);
        Instantiate(cars[Random.Range(2, cars.Count)], roadCar3StartPoint.position, transform.rotation * Quaternion.Euler(0f, 0f, 180f));
        Instantiate(cars[Random.Range(2, cars.Count)], roadCar4StartPoint.position, Quaternion.identity);
    }
    private void Update()
    {
        if (!gameOver && !gameWin)
        {
            timer += Time.deltaTime;
            if (timer >= spawnTimer)
            {
                Spawner();
            }
        }

    }
    void Spawner()
    {
        Instantiate(cars[Random.Range(2, cars.Count)], roadCar1StartPoint.position, transform.rotation * Quaternion.Euler(0f, 0f, 180f));
        Instantiate(cars[Random.Range(2, cars.Count)], roadCar2StartPoint.position, Quaternion.identity);
        Instantiate(cars[Random.Range(2, cars.Count)], roadCar3StartPoint.position, transform.rotation * Quaternion.Euler(0f, 0f, 180f));
        Instantiate(cars[Random.Range(2, cars.Count)], roadCar4StartPoint.position, Quaternion.identity);
        timer = 0f;
        spawnTimer = 2f;
    }

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    public bool GameWin
    {
        get { return gameWin; }
        set { gameWin = value; }
    }
}
