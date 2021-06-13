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

    void Start()
    {
        player1Car = GameObject.FindGameObjectWithTag("Player1Car").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (player1Car != null)
        {
            if (Vector2.Distance(transform.position, player1Car.position) > stopDistance)
            {
                transform.position = Vector2.SmoothDamp(transform.position, player1Car.position, ref velocity, 0.5f, speed);
                transform.rotation = player1Car.rotation;
            }

        }
    }
}
