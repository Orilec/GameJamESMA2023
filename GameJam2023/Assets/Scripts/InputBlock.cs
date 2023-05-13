using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlock : DropSlot
{
    [SerializeField] private KeyCode _keyCode;
    public override void OnElementConnected(DragDrop element)
    {
        var actionBlock = element.GetComponent<ActionBlock>();
        if(actionBlock != null)
        {
            
        }
    }
}
