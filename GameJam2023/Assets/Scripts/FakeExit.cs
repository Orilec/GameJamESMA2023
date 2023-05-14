using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeExit : MonoBehaviour
{

    public ShakeCamera cameraToShake;
    public Transform topBar;
    public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var controller = collision.gameObject.GetComponent<PlayerController>();
        if(controller != null)
        {
            cameraToShake.TriggerShake();
            topBar.position = destination.position; 
            topBar.rotation = destination.rotation; 
        }
    }

}
