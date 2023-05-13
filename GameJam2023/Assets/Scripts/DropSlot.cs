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

    private void OnTriggerExit2D(Collider2D collision)
    {
        var dragdrop = collision.GetComponent<DragDrop>();
        if (dragdrop != null)
        {
            OnElementDeconnected(dragdrop);
        }
    }

    public virtual void OnElementConnected(DragDrop element)
    {
        Debug.Log("Connected");
    }

    public virtual void OnElementDeconnected(DragDrop element)
    {
        Debug.Log("Deconnected");
    }
}
