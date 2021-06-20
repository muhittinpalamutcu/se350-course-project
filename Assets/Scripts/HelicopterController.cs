using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{

    [HideInInspector]
    public GameController gameController;

    public Animator animator;
    public Transform helicopterTargetPoint;

    private float moveSpeed = 7f;
    float timeToFly = 2f;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GameWin)
        {
            animator.enabled = true;
            if (timeToFly > 0)
            {
                timeToFly -= Time.deltaTime;
            }
            else
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, helicopterTargetPoint.position, step);
            }
        }
    }
}
