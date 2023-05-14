using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public InputManager InputManager;
    public PlayerController PlayerController;
    public CursorLock CursorLock;
    public GameObject Filter;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.enabled = false;
    }

    public void PlayLevel()
    {
        InputManager.enabled = true;
        Filter.SetActive(false);
        PlayerController.DisableDrag();
    }
}
