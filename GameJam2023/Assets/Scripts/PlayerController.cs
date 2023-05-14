using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private bool _isInRange;
    private Door _doorToDestroy;
    [SerializeField] private float _speed, _distanceToCheck;
    [SerializeField] private List<Collidables> _collidables;
    [SerializeField] private List<MovingPlatform> _movingPlatforms;


    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(isGrounded());
    }

    public void Jump(PlayerController p)
    {
        if (isGrounded())
        {
            myRB.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }

    public void Move(PlayerController p, int direction)
    {

        transform.position += _speed * Vector3.right * direction * Time.deltaTime;
    }

    public void Interact(PlayerController p)
    {
        if(_isInRange && _doorToDestroy!= null)
        {
            _doorToDestroy.Destroydoor();
        }
    }

    public void ToggleCollidables(PlayerController p)
    {
        foreach (var collidable in _collidables)
        {
            collidable.ToggleCollidable();
        }
    }

    public void ToggleMovables(PlayerController p)
    {
        foreach (var movable in _movingPlatforms)
        {
            movable.SetMoving();
        }
    }


    public void SetInRange(bool inRange, Door door)
    {
        _isInRange = inRange;
        _doorToDestroy = door;
    }

    public bool isGrounded()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _distanceToCheck))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
