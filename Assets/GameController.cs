using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject player1Car;
    public GameObject policeCar;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player1Car, new Vector3(-30.7999992f, 6.15999985f, 0), transform.rotation * Quaternion.Euler(0f, 0f, 270f));
        Instantiate(policeCar, new Vector3(-46.1100006f, 5.98000002f, 0), transform.rotation * Quaternion.Euler(0f, 0f, 270f));

    }
}
