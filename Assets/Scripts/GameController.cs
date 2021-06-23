using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Canvas infoCanvas;
    public Text countDown;
    public List<GameObject> cars = new List<GameObject>();

    float spawnTimer = 2f;
    float timer = 0f;
    float winTimer = 7f;
    float timeToStart = 5f;
    private bool gameOver = false;
    private bool gameWin = false;
    private bool startGame = false;


    public Animator transitionAnim;

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
        //if (!gameOver && !gameWin)
        if (!gameOver)
        {
            timer += Time.deltaTime;
            if (timer >= spawnTimer)
            {
                Spawner();
            }
        }

        if (timeToStart > 0)
        {
            timeToStart -= Time.deltaTime;
            string seconds = (timeToStart % 60).ToString("f0");
            countDown.text = seconds;
        }
        else
        {
            StartGame = true;
            infoCanvas.enabled = false;
        }

        if (gameWin)
        {
            if (winTimer > 0)
            {
                winTimer -= Time.deltaTime;
            }
            else
            {
                LoadScene("Win");
            }

        }

        if (gameOver)
        {
            LoadScene("Lose");
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
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

    public bool StartGame
    {
        get { return startGame; }
        set { startGame = value; }
    }
}
