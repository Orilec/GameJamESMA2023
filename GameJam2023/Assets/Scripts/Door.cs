using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerController = collision.transform.GetComponent<PlayerController>();
        if (playerController != null)
        {
            //playerController.SetInRange(true); 
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var playerController = collision.transform.GetComponent<PlayerController>();
        if (playerController != null)
        {
            //playerController.SetInRange(false);
        }
    }
}
