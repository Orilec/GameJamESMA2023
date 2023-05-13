using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlock : DropSlot
{
    [SerializeField] private KeyCode _keyCode;
    private InputManager myIM; 
    private PlayerController player;
    private ActionBlock actionBlockLinked; 

    private void Start()
    {
        myIM = FindObjectOfType<InputManager>();
        player = FindObjectOfType<PlayerController>();
        
    }

    public override void OnElementConnected(DragDrop element)
    {
        var actionBlock = element.GetComponent<ActionBlock>();
        if (actionBlockLinked != null)
        {
            actionBlockLinked.SetPosition(actionBlock.GetPreviousPosition()); 
        }

        actionBlockLinked = actionBlock; 

        
        if(actionBlock != null)
        {
            Debug.Log("Action"); 
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

    public override void OnElementDeconnected(DragDrop element)
    {
        actionBlockLinked = null;
        myIM.GetKeyWithKeyCode(_keyCode).ClearDown();
        myIM.GetKeyWithKeyCode(_keyCode).ClearUp();
        myIM.GetKeyWithKeyCode(_keyCode).ClearPressed();

    }
}
