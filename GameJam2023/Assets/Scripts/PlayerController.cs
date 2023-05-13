using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRB;

    public static PlayerController instance;


    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    public void Jump()
    {
        myRB.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
    }

    public void Attack()
    {
        Debug.Log("J'attaque !");
    }
}
