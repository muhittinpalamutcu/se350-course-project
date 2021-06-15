using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCarsController : MonoBehaviour
{
    [HideInInspector]
    public GameController gameController;

    float moveSpeed=4f;
    public Vector3 currentposition;
    Rigidbody2D car;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody2D>();
        currentposition = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameController.GameOver);
        if (gameController.GameOver==false)
        {
            if (new Vector3(-24.6299992f, 16.9300003f, 0f) == currentposition)
            {
                float step = moveSpeed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-24.5939999f, -17.5170002f, 0f), step);
            }
            if (new Vector3(-26.7000008f, -14.3599997f, 0f) == currentposition)
            {
                float step = moveSpeed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-27.0400009f, 19.0100002f, 0f), step);
            }
        }
        if (gameController.GameOver==true)
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
