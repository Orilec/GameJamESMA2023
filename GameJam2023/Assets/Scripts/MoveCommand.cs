using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveCommand : ICommand
{
    private int _moveDirection;
    private Vector3 _previousPosition;

    public MoveCommand(int _direction)
    {
        _moveDirection = _direction;

    }

    public void Execute(PlayerController _player)
    {

        _player.transform.position += Vector3.right * _moveDirection; 
        



    }

    public void Undo(PlayerController _player)
    {
        
    }
}
