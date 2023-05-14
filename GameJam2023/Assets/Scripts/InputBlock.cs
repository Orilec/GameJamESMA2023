using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlock : DropSlot
{
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private RectTransform _rectTransform;
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
        var actionBlockRectTransform = actionBlockLinked.GetComponent<RectTransform>();
        actionBlockRectTransform.anchoredPosition = new Vector2(_rectTransform.anchoredPosition.x, _rectTransform.anchoredPosition.y);

        
        if(actionBlock != null)
        {
            Debug.Log("Action"); 
            if(actionBlock.action == "MoveLeft")
            {
                myIM.GetKeyWithKeyCode(_keyCode).AttributePressed((PlayerController p) => player.Move(p, -1),true);
                myIM.GetKeyWithKeyCode(_keyCode).AttributeUp((PlayerController p) => player.ResetAcceleration(p),true);
            }

            if (actionBlock.action == "MoveRight")
            {
                myIM.GetKeyWithKeyCode(_keyCode).AttributePressed((PlayerController p) => player.Move(p, 1), true);
                myIM.GetKeyWithKeyCode(_keyCode).AttributeUp((PlayerController p) => player.ResetAcceleration(p), true);
            }

            if (actionBlock.action == "Jump")
            {
                myIM.GetKeyWithKeyCode(_keyCode).AttributeDown((PlayerController p) => player.Jump(p),true);
            }

            if (actionBlock.action == "Interact")
            {
                myIM.GetKeyWithKeyCode(_keyCode).AttributeDown((PlayerController p) => player.Interact(p), true);
            }

            if (actionBlock.action == "IsCollidable")
            {
                myIM.GetKeyWithKeyCode(_keyCode).AttributeDown((PlayerController p) => player.ToggleCollidables(p), true);
            }

            if (actionBlock.action == "IsMovable")
            {
                myIM.GetKeyWithKeyCode(_keyCode).AttributeDown((PlayerController p) => player.ToggleMovables(p), true);
            }


        }
    }

    public override void OnElementDeconnected(DragDrop element)
    {
        if(actionBlockLinked == element)
        {
            actionBlockLinked = null;
            myIM.GetKeyWithKeyCode(_keyCode).ClearDown();
            myIM.GetKeyWithKeyCode(_keyCode).ClearUp();
            myIM.GetKeyWithKeyCode(_keyCode).ClearPressed();
        }
    }
}
