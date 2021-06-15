using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float accelerationRate = 30.0f;
    public float turnFactor = 3.5f;
    public float driftRate = 0.95f;
    public float maxSpeed = 20;


    private float accelerationInput = 0;
    private float steeringInput = 0;
    private float rotatingAngle = -90f;
    private float velocityVsUp = 0;

    Rigidbody2D carRigidbody2D;
    void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        KillOrthogonalVelocity();
        ApplySteering();
    }

    void ApplyEngineForce()
    {

        velocityVsUp = Vector2.Dot(transform.up, carRigidbody2D.velocity);

        //Limiting forward speed
        if (velocityVsUp > maxSpeed && accelerationInput > 0)
        {
            return;
        }

        //Limiting reverse speed
        if (velocityVsUp < -maxSpeed * 0.5f && accelerationInput > 0)
        {
            return;
        }

        //For limiting in any direction especially sliding sides
        if (carRigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
        {
            return;
        }

        if (accelerationInput == 0)
        {
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            carRigidbody2D.drag = 0;
        }

        //For the force that is going to be applied to car
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationRate;

        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);

    }

    void ApplySteering()
    {
        float minSpeedBeforeTurning = carRigidbody2D.velocity.magnitude / 8;
        minSpeedBeforeTurning = Mathf.Clamp01(minSpeedBeforeTurning);

        //if minSpeedBeforeTurning 0 then our car not rotating at all
        rotatingAngle -= steeringInput * turnFactor * minSpeedBeforeTurning;
        carRigidbody2D.MoveRotation(rotatingAngle);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

        carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftRate;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

}
