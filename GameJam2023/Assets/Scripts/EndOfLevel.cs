using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private string _sceneToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerController = collision.GetComponent<PlayerController>();
        if(playerController != null)
        {
            Debug.Log("collision");
            _sceneChanger.LoadAScene(_sceneToLoad);
        }
    }
}
