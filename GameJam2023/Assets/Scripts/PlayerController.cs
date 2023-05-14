using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    public Animator animator; 
    private bool _isInRange;
    private Door _doorToDestroy;
    private float _acceleration;
    [SerializeField] private float _speed, _distanceToCheck, _jumpForce;
    [SerializeField] private List<Collidables> _collidables;
    [SerializeField] private List<MovingPlatform> _movingPlatforms;
    [SerializeField] private List<ActionBlock> _actionBlocks;


    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", _acceleration);
        animator.SetBool("IsJumping", !isGrounded());
    }


    public void Jump(PlayerController p)
    {
        if (isGrounded())
        {
            myRB.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true); 
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void Move(PlayerController p, int direction)
    {
        
        transform.GetComponent<SpriteRenderer>().flipX = direction != 1;
        var accelerationVector = _speed * Vector3.right * direction * Time.deltaTime;
        transform.position += accelerationVector;
        _acceleration = accelerationVector.magnitude;
    }

    public void ResetAcceleration(PlayerController p)
    {
        _acceleration = 0; 
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

    public void DisableDrag()
    {
        foreach (var item in _actionBlocks)
        {
            item.DisableDragable();
        }
    }


    public void SetInRange(bool inRange, Door door)
    {
        _isInRange = inRange;
        _doorToDestroy = door;
    }

    public bool isGrounded()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _distanceToCheck, 1 << 6))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
