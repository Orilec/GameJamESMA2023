using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePortalPosition : MonoBehaviour
{
    [SerializeField] private Transform _portal, _destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();
        if(player != null)
        {
            _portal.position = _destination.position;
        }
    }
}
