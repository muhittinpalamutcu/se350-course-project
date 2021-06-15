using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool gameOver =false;
    public GameObject player1Car;
    public GameObject policeCar;
    public GameObject roadCar1;
    public GameObject roadCar2;
    float spawnTimer = 2f;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player1Car, new Vector3(-30.7999992f, 6.15999985f, 0), transform.rotation * Quaternion.Euler(0f, 0f, 270f));
        Instantiate(policeCar, new Vector3(-46.1100006f, 5.98000002f, 0), transform.rotation * Quaternion.Euler(0f, 0f, 270f));
        Instantiate(roadCar1, new Vector3(-24.6299992f, 16.9300003f, 0f), Quaternion.identity);

        Instantiate(roadCar2, new  Vector3(-26.7000008f, -14.3599997f, 0f), Quaternion.identity);
    }
    private void Update()
    {
       
        if (!gameOver)
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
        Instantiate(roadCar1, new Vector3(-24.6299992f, 16.9300003f, 0f), Quaternion.identity);
        Instantiate(roadCar2, new Vector3(-26.7000008f, -14.3599997f, 0f), Quaternion.identity);
        timer = 0f;
        spawnTimer = 2f;
     }

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }


}
