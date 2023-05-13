using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlock : DropSlot
{
    [SerializeField] private KeyCode _keyCode;
    private InputManager myIM; 
    private PlayerController player; 

    private void Start()
    {
        myIM = FindObjectOfType<InputManager>();
        player = FindObjectOfType<PlayerController>();
        
    }

    public override void OnElementConnected(DragDrop element)
    {
        var actionBlock = element.GetComponent<ActionBlock>();
        if(actionBlock != null)
        {
            if(actionBlock.action == "MoveLeft")
            {
                myIM.GetKeyWithKeyCode(_keyCode).AttributePressed((PlayerController p) => player.Move(p, -1),true);
            }

            if (actionBlock.action == "MoveRight")
            {
                myIM.GetKeyWithKeyCode(_keyCode).AttributePressed((PlayerController p) => player.Move(p, 1), true);
            }

            if (actionBlock.action == "Jump")
            {
                myIM.GetKeyWithKeyCode(_keyCode).AttributeDown((PlayerController p) => player.Jump(p),true);
            }

            if (actionBlock.action == "Interact")
            {
                myIM.GetKeyWithKeyCode(_keyCode).AttributeDown((PlayerController p) => player.Interact(p), true);
            }


        }
    }
}
