using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Collidables : MonoBehaviour
{
    [SerializeField] private Collider2D _tilemapCollider;
    [SerializeField] private Tilemap _tilemap;
    public void ToggleCollidable()
    {
        _tilemapCollider.enabled = !_tilemapCollider.enabled;

    }
}
