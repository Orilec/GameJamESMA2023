using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var dragdrop = collision.GetComponent<DragDrop>();
        if(dragdrop != null)
        {
            OnElementConnected(dragdrop);
        }
    }

    public virtual void OnElementConnected(DragDrop element)
    {
        Debug.Log("Connected");
    }
}
