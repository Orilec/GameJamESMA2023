using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetInRange(true, this); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var playerController = collision.transform.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetInRange(false, this);
        }
    }

    public void Destroydoor()
    {
        Destroy(transform.parent.gameObject);
    }
}
