using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;




    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

        
    }

    void Update()
    {

    }

    public void Jump(PlayerController p)
    {
        Debug.Log("Test");
        myRB.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    public void Move(PlayerController p, int direction)
    {

        transform.position += 0.01f * Vector3.right;
    }


    public void Attack()
    {
        Debug.Log("J'attaque !");
    }
}
