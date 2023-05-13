using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float _speed;
    [SerializeField] private List<Collidables> _collidables;


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

        transform.position += _speed * Vector3.right * direction * Time.deltaTime;
    }

    public void Interact(PlayerController p)
    {

        Debug.Log("Salut"); 
    }

    public void ToggleCollidables(PlayerController p)
    {
        foreach (var collidable in _collidables)
        {
            collidable.ToggleCollidable();
        }
    }


    public void Attack()
    {
        Debug.Log("J'attaque !");
    }
}
